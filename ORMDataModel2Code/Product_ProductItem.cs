﻿using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Uwp_App5.RapidCM_PGS_Dev
{

    public partial class Product_ProductItem
    {
        public Product_ProductItem(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}