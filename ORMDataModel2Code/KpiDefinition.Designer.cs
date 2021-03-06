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

    public partial class KpiDefinition : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        string fTargetObjectType;
        [Size(SizeAttribute.Unlimited)]
        public string TargetObjectType
        {
            get { return fTargetObjectType; }
            set { SetPropertyValue<string>(nameof(TargetObjectType), ref fTargetObjectType, value); }
        }
        DateTime fChanged1;
        [Persistent(@"Changed")]
        public DateTime Changed1
        {
            get { return fChanged1; }
            set { SetPropertyValue<DateTime>(nameof(Changed1), ref fChanged1, value); }
        }
        KpiInstance fKpiInstance;
        [Association(@"KpiDefinitionReferencesKpiInstance")]
        public KpiInstance KpiInstance
        {
            get { return fKpiInstance; }
            set { SetPropertyValue<KpiInstance>(nameof(KpiInstance), ref fKpiInstance, value); }
        }
        string fName;
        public string Name
        {
            get { return fName; }
            set { SetPropertyValue<string>(nameof(Name), ref fName, value); }
        }
        bool fActive;
        public bool Active
        {
            get { return fActive; }
            set { SetPropertyValue<bool>(nameof(Active), ref fActive, value); }
        }
        string fCriteria;
        [Size(SizeAttribute.Unlimited)]
        public string Criteria
        {
            get { return fCriteria; }
            set { SetPropertyValue<string>(nameof(Criteria), ref fCriteria, value); }
        }
        string fExpression;
        [Size(SizeAttribute.Unlimited)]
        public string Expression
        {
            get { return fExpression; }
            set { SetPropertyValue<string>(nameof(Expression), ref fExpression, value); }
        }
        double fGreenZone;
        public double GreenZone
        {
            get { return fGreenZone; }
            set { SetPropertyValue<double>(nameof(GreenZone), ref fGreenZone, value); }
        }
        double fRedZone;
        public double RedZone
        {
            get { return fRedZone; }
            set { SetPropertyValue<double>(nameof(RedZone), ref fRedZone, value); }
        }
        string fRange;
        public string Range
        {
            get { return fRange; }
            set { SetPropertyValue<string>(nameof(Range), ref fRange, value); }
        }
        bool fCompare;
        public bool Compare
        {
            get { return fCompare; }
            set { SetPropertyValue<bool>(nameof(Compare), ref fCompare, value); }
        }
        string fRangeToCompare;
        public string RangeToCompare
        {
            get { return fRangeToCompare; }
            set { SetPropertyValue<string>(nameof(RangeToCompare), ref fRangeToCompare, value); }
        }
        int fMeasurementFrequency;
        public int MeasurementFrequency
        {
            get { return fMeasurementFrequency; }
            set { SetPropertyValue<int>(nameof(MeasurementFrequency), ref fMeasurementFrequency, value); }
        }
        int fMeasurementMode;
        public int MeasurementMode
        {
            get { return fMeasurementMode; }
            set { SetPropertyValue<int>(nameof(MeasurementMode), ref fMeasurementMode, value); }
        }
        int fDirection;
        public int Direction
        {
            get { return fDirection; }
            set { SetPropertyValue<int>(nameof(Direction), ref fDirection, value); }
        }
        DateTime fChangedOn;
        public DateTime ChangedOn
        {
            get { return fChangedOn; }
            set { SetPropertyValue<DateTime>(nameof(ChangedOn), ref fChangedOn, value); }
        }
        string fSuppressedSeries;
        public string SuppressedSeries
        {
            get { return fSuppressedSeries; }
            set { SetPropertyValue<string>(nameof(SuppressedSeries), ref fSuppressedSeries, value); }
        }
        bool fEnableCustomizeRepresentation;
        public bool EnableCustomizeRepresentation
        {
            get { return fEnableCustomizeRepresentation; }
            set { SetPropertyValue<bool>(nameof(EnableCustomizeRepresentation), ref fEnableCustomizeRepresentation, value); }
        }
        [Association(@"KpiInstanceReferencesKpiDefinition")]
        public XPCollection<KpiInstance> KpiInstances { get { return GetCollection<KpiInstance>(nameof(KpiInstances)); } }
    }

}
