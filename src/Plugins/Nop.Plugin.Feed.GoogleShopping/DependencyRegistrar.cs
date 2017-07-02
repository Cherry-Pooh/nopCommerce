using System;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Feed.GoogleShopping.Data;
using Nop.Plugin.Feed.GoogleShopping.Domain;
using Nop.Plugin.Feed.GoogleShopping.Services;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Feed.GoogleShopping
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="services">Services</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(IServiceCollection services, ITypeFinder typeFinder, NopConfig config)
        {
            services.AddScoped<IGoogleService, GoogleService>();

            //data context and repository
            this.RegisterPluginDataContext<GoogleProductObjectContext>(services);
            this.RegisterPluginRepository<GoogleProductRecord, GoogleProductObjectContext>(services);
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get
            {
                return 1;
            }
        }
    }
}