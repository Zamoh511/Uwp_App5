﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Uwp_App5.RapidCM_PGS_Dev
{

    public partial class Library_Supplier : XPLiteObject
    {
        int fID;
        [Key(true)]
        public int ID
        {
            get { return fID; }
            set { SetPropertyValue<int>(nameof(ID), ref fID, value); }
        }
        string fName;
        [Size(50)]
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue<string>(nameof(Name), ref fName, value); }
        }
        string fDescription;
        [Size(300)]
        public string Description
        {
            get { return fDescription; }
            set { SetPropertyValue<string>(nameof(Description), ref fDescription, value); }
        }
        [Association(@"Container_PackedReferencesLibrary_Supplier")]
        public XPCollection<Container_Packed> Container_Packeds { get { return GetCollection<Container_Packed>(nameof(Container_Packeds)); } }
        [Association(@"Product_ProductReceiveReferencesLibrary_Supplier")]
        public XPCollection<Product_ProductReceive> Product_ProductReceives { get { return GetCollection<Product_ProductReceive>(nameof(Product_ProductReceives)); } }
    }

}
