﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using LinqToDB;
using LinqToDB.Data;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Core.Domain.Common;
using Nop.Core.Events;

namespace Nop.Data
{
    /// <summary>
    /// Represents the Entity repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields

        private readonly IEventPublisher _eventPublisher;
        private readonly INopDataProvider _dataProvider;
        private readonly IStaticCacheManager _staticCacheManager;
        private ITable<TEntity> _entities;

        #endregion

        #region Ctor

        public EntityRepository(IEventPublisher eventPublisher, INopDataProvider dataProvider, IStaticCacheManager staticCacheManager)
        {
            _eventPublisher = eventPublisher;
            _dataProvider = dataProvider;
            _staticCacheManager = staticCacheManager;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get the entity entry
        /// </summary>
        /// <param name="id">Entity entry identifier</param>
        /// <param name="cacheTime">Cache time in minutes; pass null to use default value; pass 0 to do not cache</param>
        /// <returns>Entity entry</returns>
        public virtual TEntity GetById(int? id, int? cacheTime = null)
        {
            if (!id.HasValue || id == 0)
                return null;

            TEntity getEntity()
            {
                return Entities.FirstOrDefault(e => e.Id == Convert.ToInt32(id));
            }

            if (cacheTime == 0)
                return getEntity();

            //caching
            var cacheKey = new CacheKey(BaseEntity.GetEntityCacheKey(typeof(TEntity), id));
            if (cacheTime.HasValue)
                cacheKey.CacheTime = cacheTime.Value;
            else
                cacheKey = _staticCacheManager.PrepareKeyForDefaultCache(cacheKey);

            return _staticCacheManager.Get(cacheKey, getEntity);
        }


        /// <summary>
        /// Get entity entries by identifiers
        /// </summary>
        /// <param name="ids">Entity entry identifiers</param>
        /// <param name="cacheKey">Cache key; pass null to don't cache</param>
        /// <returns>Entity entries</returns>
        public virtual IList<TEntity> GetByIds(IList<int> ids, CacheKey cacheKey = null)
        {
            if (!ids?.Any() ?? true)
                return new List<TEntity>();

            IList<TEntity> getByIds()
            {
                var query = Table;
                if (typeof(TEntity).GetInterface(nameof(ISoftDeletedEntity)) != null)
                    query = Entities.OfType<ISoftDeletedEntity>().Where(entry => !entry.Deleted).OfType<TEntity>();

                //get entries 
                var entries = query.Where(entry => ids.Contains(entry.Id)).ToList();

                //sort by passed identifiers
                var sortedEntries = new List<TEntity>();
                foreach (var id in ids)
                {
                    var sortedEntry = entries.FirstOrDefault(entry => entry.Id == id);
                    if (sortedEntry != null)
                        sortedEntries.Add(sortedEntry);
                }

                return sortedEntries;
            }

            if (cacheKey == null)
                return getByIds();

            //caching
            return _staticCacheManager.Get(cacheKey, getByIds);
        }
        
        /// <summary>
        /// Insert the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Insert(TEntity entity, bool publishEvent = true)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dataProvider.InsertEntity(entity);

            //event notification
            if (publishEvent)
                _eventPublisher.EntityInserted(entity);
        }


        /// <summary>
        /// Insert entity entries
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Insert(IList<TEntity> entities, bool publishEvent = true)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            using (var transaction = new TransactionScope())
            {
                _dataProvider.BulkInsertEntities(entities);
                transaction.Complete();
            }

            
            if (!publishEvent) 
                return;

            //event notification
            foreach (var entity in entities)
                _eventPublisher.EntityInserted(entity);
        }

        /// <summary>
        /// Loads the original copy of the entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>Copy of the passed entity</returns>
        public virtual TEntity LoadOriginalCopy(TEntity entity)
        {
            return _dataProvider.GetTable<TEntity>()
                .FirstOrDefault(e => e.Id == Convert.ToInt32(entity.Id));
        }
        
        /// <summary>
        /// Update the entity entry
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Update(TEntity entity, bool publishEvent = true)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _dataProvider.UpdateEntity(entity);

            //event notification
            if (publishEvent)
                _eventPublisher.EntityUpdated(entity);
        }
        
        /// <summary>
        /// Update entity entries
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Update(IList<TEntity> entities, bool publishEvent = true)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            if(!entities.Any())
                return;

            foreach (var entity in entities) 
                Update(entity, publishEvent);
        }

        /// <summary>
        /// Delete the entity entry
        /// </summary>
        /// <param name="entity">Entity entry</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Delete(TEntity entity, bool publishEvent = true)
        {
            switch (entity)
            {
                case null:
                    throw new ArgumentNullException(nameof(entity));
                case ISoftDeletedEntity softDeletedEntity:
                    softDeletedEntity.Deleted = true;
                    _dataProvider.UpdateEntity(entity);
                    break;
                default:
                    _dataProvider.DeleteEntity(entity);
                    break;
            }

            //event notification
            if (publishEvent)
                _eventPublisher.EntityDeleted(entity);
        }

        /// <summary>
        /// Delete entity entries
        /// </summary>
        /// <param name="entities">Entity entries</param>
        /// <param name="publishEvent">Whether to publish event notification</param>
        public virtual void Delete(IList<TEntity> entities, bool publishEvent = true)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            if (entities.OfType<ISoftDeletedEntity>().Any())
            {
                foreach (var entity in entities)
                    if (entity is ISoftDeletedEntity softDeletedEntity)
                    {
                        softDeletedEntity.Deleted = true;
                        _dataProvider.UpdateEntity(entity);
                    }
            }
            else
                _dataProvider.BulkDeleteEntities(entities);

            //event notification
            if (!publishEvent)
                return;

            foreach (var entity in entities)
                _eventPublisher.EntityDeleted(entity);
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition</param>
        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            _dataProvider.BulkDeleteEntities(predicate);
        }

        /// <summary>
        /// Executes command using System.Data.CommandType.StoredProcedure command type
        /// and returns results as collection of values of specified type
        /// </summary>
        /// <param name="storeProcedureName">Store procedure name</param>
        /// <param name="dataParameters">Command parameters</param>
        /// <returns>Collection of query result records</returns>
        public virtual IList<TEntity> EntityFromSql(string storeProcedureName, params DataParameter[] dataParameters)
        {
            return _dataProvider.QueryProc<TEntity>(storeProcedureName, dataParameters?.ToArray());
        }

        /// <summary>
        /// Truncates database table
        /// </summary>
        /// <param name="resetIdentity">Performs reset identity column</param>
        public virtual void Truncate(bool resetIdentity = false)
        {
            _dataProvider.GetTable<TEntity>().Truncate(resetIdentity);
        }
        
        /// <summary>
        /// Get all entity entries
        /// </summary>
        /// <param name="func">Function to select entries</param>
        /// <param name="cacheKey">Cache key; pass null to don't cache</param>
        /// <returns>Entity entries</returns>
        public virtual IList<TEntity> GetAll(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null, CacheKey cacheKey = null)
        {
            var query = _dataProvider.GetTable<TEntity>() as IQueryable<TEntity>;
            if (func != null)
                query = func.Invoke(query);

            return cacheKey == null ? query.ToList() : _staticCacheManager.Get(cacheKey, query.ToList);
        }

        /// <summary>
        /// Get paged list of all entity entries
        /// </summary>
        /// <param name="func">Function to select entries</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="getOnlyTotalCount">Whether to get only the total number of entries without actually loading data</param>
        /// <returns>Paged list of entity entries</returns>
        public virtual IPagedList<TEntity> GetAllPaged(Func<IQueryable<TEntity>, IQueryable<TEntity>> func = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false)
        {
            var query = _dataProvider.GetTable<TEntity>() as IQueryable<TEntity>;
            if (func != null)
                query = func.Invoke(query);

            return new PagedList<TEntity>(query, pageIndex, pageSize, getOnlyTotalCount);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<TEntity> Table => Entities;

        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected virtual ITable<TEntity> Entities => _entities ?? (_entities = _dataProvider.GetTable<TEntity>());

        #endregion
    }
}