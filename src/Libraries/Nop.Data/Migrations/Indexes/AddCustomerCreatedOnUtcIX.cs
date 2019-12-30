﻿using FluentMigrator;
using Nop.Core.Domain.Customers;
using Nop.Data.Extensions;

namespace Nop.Data.Migrations.Indexes
{
    [Migration(637123449689037685)]
    public class AddCustomerCreatedOnUtcIX : AutoReversingMigration
    {
        #region Methods          

        public override void Up()
        {
            this.AddIndex("IX_Customer_CreatedOnUtc", nameof(Customer), i => i.Descending(),
                nameof(Customer.CreatedOnUtc));
        }

        #endregion
    }
}