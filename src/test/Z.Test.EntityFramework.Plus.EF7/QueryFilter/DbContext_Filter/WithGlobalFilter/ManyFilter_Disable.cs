﻿// Description: EF Bulk Operations & Utilities | Bulk Insert, Update, Delete, Merge from database.
// Website & Documentation: https://github.com/zzzprojects/Entity-Framework-Plus
// Forum: http://zzzprojects.uservoice.com/forums/283924-entity-framework-plus
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Z.Test.EntityFramework.Plus
{
    public partial class QueryFilter_DbContext_Filter
    {
        [TestMethod]
        public void WithGlobalFilter_ManyFilter_Disable()
        {
            FilterEntityHelper.Clear();
            FilterEntityHelper.AddTen();

            using (var ctx = new EntityContext(true, enableFilter1: false, enableFilter2: false, enableFilter3: false, enableFilter4: false))
            {
                Assert.AreEqual(45, ctx.FilterEntities.Sum(x => x.ColumnInt));
            }
        }
    }
}