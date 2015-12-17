﻿// Description: EF Bulk Operations & Utilities | Bulk Insert, Update, Delete, Merge from database.
// Website & Documentation: https://github.com/zzzprojects/Entity-Framework-Plus
// Forum: http://zzzprojects.uservoice.com/forums/283924-entity-framework-plus
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z.EntityFramework.Plus;

namespace Z.Test.EntityFramework.Plus
{
    public partial class QueryFilter_DbContext_Filter
    {
        [TestMethod]
        public void WithInstanceFilter_ManyFilter_Enable()
        {
            using (var ctx = new EntityContext())
            {
                ctx.Filter<FilterEntity>(FilterEntityHelper.Filter.Filter1, entities => entities.Where(x => x.ColumnInt != 1), false);
                ctx.Filter<IFilterEntity>(FilterEntityHelper.Filter.Filter2, entities => entities.Where(x => x.ColumnInt != 2), false);
                ctx.Filter<BaseFilterEntity>(FilterEntityHelper.Filter.Filter3, entities => entities.Where(x => x.ColumnInt != 3), false);
                ctx.Filter<IBaseFilterEntity>(FilterEntityHelper.Filter.Filter4, entities => entities.Where(x => x.ColumnInt != 4), false);

                ctx.Filter(FilterEntityHelper.Filter.Filter1).Enable();
                ctx.Filter(FilterEntityHelper.Filter.Filter2).Enable();
                ctx.Filter(FilterEntityHelper.Filter.Filter3).Enable();
                ctx.Filter(FilterEntityHelper.Filter.Filter4).Enable();

                Assert.AreEqual(35, ctx.FilterEntities.Sum(x => x.ColumnInt));
            }
        }
    }
}