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

    public partial class Library_TrimAction : XPLiteObject
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
        [Association(@"Container_TrimReferencesLibrary_TrimAction")]
        public XPCollection<Container_Trim> Container_Trims { get { return GetCollection<Container_Trim>(nameof(Container_Trims)); } }
    }

}
