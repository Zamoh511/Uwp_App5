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

    public partial class ShuttleTrucks : XPLiteObject
    {
        int fID;
        [Key(true)]
        public int ID
        {
            get { return fID; }
            set { SetPropertyValue<int>(nameof(ID), ref fID, value); }
        }
        string fTruckRegistration;
        [Size(50)]
        public string TruckRegistration
        {
            get { return fTruckRegistration; }
            set { SetPropertyValue<string>(nameof(TruckRegistration), ref fTruckRegistration, value); }
        }
        string fTrailer1Registration;
        [Size(50)]
        public string Trailer1Registration
        {
            get { return fTrailer1Registration; }
            set { SetPropertyValue<string>(nameof(Trailer1Registration), ref fTrailer1Registration, value); }
        }
        string fTrailer2Registration;
        [Size(50)]
        public string Trailer2Registration
        {
            get { return fTrailer2Registration; }
            set { SetPropertyValue<string>(nameof(Trailer2Registration), ref fTrailer2Registration, value); }
        }
        Library_Transporter fTransporterID;
        [Association(@"ShuttleTrucksReferencesLibrary_Transporter")]
        public Library_Transporter TransporterID
        {
            get { return fTransporterID; }
            set { SetPropertyValue<Library_Transporter>(nameof(TransporterID), ref fTransporterID, value); }
        }
        double fTarWeight;
        public double TarWeight
        {
            get { return fTarWeight; }
            set { SetPropertyValue<double>(nameof(TarWeight), ref fTarWeight, value); }
        }
        DateTime fDateWeighed;
        public DateTime DateWeighed
        {
            get { return fDateWeighed; }
            set { SetPropertyValue<DateTime>(nameof(DateWeighed), ref fDateWeighed, value); }
        }
        int fStatus;
        public int Status
        {
            get { return fStatus; }
            set { SetPropertyValue<int>(nameof(Status), ref fStatus, value); }
        }
        [Association(@"BookingReference_ProductDispatchReferencesShuttleTrucks")]
        public XPCollection<BookingReference_ProductDispatch> BookingReference_ProductDispatchs { get { return GetCollection<BookingReference_ProductDispatch>(nameof(BookingReference_ProductDispatchs)); } }
        [Association(@"Product_ProductDispatchReferencesShuttleTrucks")]
        public XPCollection<Product_ProductDispatch> Product_ProductDispatchs { get { return GetCollection<Product_ProductDispatch>(nameof(Product_ProductDispatchs)); } }
        [Association(@"Product_ProductReceiveReferencesShuttleTrucks")]
        public XPCollection<Product_ProductReceive> Product_ProductReceives { get { return GetCollection<Product_ProductReceive>(nameof(Product_ProductReceives)); } }
    }

}
