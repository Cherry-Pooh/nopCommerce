﻿using FluentMigrator;
using Nop.Data.Migrations;
using Nop.Plugin.Tax.Avalara.Domain;

namespace Nop.Plugin.Tax.Avalara.Data
{
    [NopMigration("2020/02/03 09:09:17:6455442")]
    public class SchemaMigration : AutoReversingMigration
    {
        protected IMigrationManager _migrationManager;

        public SchemaMigration(IMigrationManager migrationManager)
        {
            _migrationManager = migrationManager;
        }

        public override void Up()
        {
            _migrationManager.BuildTable<TaxTransactionLog>(Create);
        }
    }
}