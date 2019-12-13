﻿using System.Data;
using FluentMigrator;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Orders;
using Nop.Data.Extensions;

namespace Nop.Data.Migrations.Orders
{
    [Migration(637121109617140897)]
    public class AddOrderRewardPointsHistoryFK : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            this.AddForeignKey(nameof(Order)
                , nameof(Order.RewardPointsHistoryEntryId)
                , nameof(RewardPointsHistory)
                , nameof(RewardPointsHistory.Id));
        }

        #endregion
    }
}