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

    public partial class TruckStopExit : XPLiteObject
    {
        int fID;
        [Key(true)]
        public int ID
        {
            get { return fID; }
            set { SetPropertyValue<int>(nameof(ID), ref fID, value); }
        }
        string fTruckScan;
        [Size(150)]
        public string TruckScan
        {
            get { return fTruckScan; }
            set { SetPropertyValue<string>(nameof(TruckScan), ref fTruckScan, value); }
        }
        string fTruckReg;
        [Size(50)]
        public string TruckReg
        {
            get { return fTruckReg; }
            set { SetPropertyValue<string>(nameof(TruckReg), ref fTruckReg, value); }
        }
        DateTime fExitTime;
        public DateTime ExitTime
        {
            get { return fExitTime; }
            set { SetPropertyValue<DateTime>(nameof(ExitTime), ref fExitTime, value); }
        }
    }

}
