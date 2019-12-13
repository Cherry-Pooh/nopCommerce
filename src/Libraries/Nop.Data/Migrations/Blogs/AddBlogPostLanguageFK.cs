﻿using System.Data;
using FluentMigrator;
using Nop.Core.Domain.Blogs;
using Nop.Core.Domain.Localization;
using Nop.Data.Extensions;

namespace Nop.Data.Migrations.Blogs
{
    [Migration(637097607595956342)]
    public class AddBlogPostLanguageFK : AutoReversingMigration
    {
        #region Methods

        public override void Up()
        {
            this.AddForeignKey(nameof(BlogPost)
                , nameof(BlogPost.LanguageId)
                , nameof(Language)
                , nameof(Language.Id)
                , Rule.Cascade);
        }

        #endregion
    }
}