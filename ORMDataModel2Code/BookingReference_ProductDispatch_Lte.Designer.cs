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

    public partial class BookingReference_ProductDispatch_Lte : XPLiteObject
    {
        int fID;
        [Key(true)]
        public int ID
        {
            get { return fID; }
            set { SetPropertyValue<int>(nameof(ID), ref fID, value); }
        }
        Order_BookingReference fBookingReferenceID;
        [Association(@"BookingReference_ProductDispatch_LteReferencesOrder_BookingReference")]
        public Order_BookingReference BookingReferenceID
        {
            get { return fBookingReferenceID; }
            set { SetPropertyValue<Order_BookingReference>(nameof(BookingReferenceID), ref fBookingReferenceID, value); }
        }
        DateTime fDispatchDate;
        public DateTime DispatchDate
        {
            get { return fDispatchDate; }
            set { SetPropertyValue<DateTime>(nameof(DispatchDate), ref fDispatchDate, value); }
        }
        Library_Transporter fTransporterID;
        [Association(@"BookingReference_ProductDispatch_LteReferencesLibrary_Transporter")]
        public Library_Transporter TransporterID
        {
            get { return fTransporterID; }
            set { SetPropertyValue<Library_Transporter>(nameof(TransporterID), ref fTransporterID, value); }
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
        int fSiteID;
        public int SiteID
        {
            get { return fSiteID; }
            set { SetPropertyValue<int>(nameof(SiteID), ref fSiteID, value); }
        }
        double fGrossWeight;
        public double GrossWeight
        {
            get { return fGrossWeight; }
            set { SetPropertyValue<double>(nameof(GrossWeight), ref fGrossWeight, value); }
        }
        DateTime fGrossWeightDate;
        public DateTime GrossWeightDate
        {
            get { return fGrossWeightDate; }
            set { SetPropertyValue<DateTime>(nameof(GrossWeightDate), ref fGrossWeightDate, value); }
        }
        double fTarWeight;
        public double TarWeight
        {
            get { return fTarWeight; }
            set { SetPropertyValue<double>(nameof(TarWeight), ref fTarWeight, value); }
        }
        DateTime fTarWeightDate;
        public DateTime TarWeightDate
        {
            get { return fTarWeightDate; }
            set { SetPropertyValue<DateTime>(nameof(TarWeightDate), ref fTarWeightDate, value); }
        }
        double fNettWeight;
        public double NettWeight
        {
            get { return fNettWeight; }
            set { SetPropertyValue<double>(nameof(NettWeight), ref fNettWeight, value); }
        }
        int fWeighbridgeID;
        public int WeighbridgeID
        {
            get { return fWeighbridgeID; }
            set { SetPropertyValue<int>(nameof(WeighbridgeID), ref fWeighbridgeID, value); }
        }
        string fGeneralComments;
        [Size(SizeAttribute.Unlimited)]
        public string GeneralComments
        {
            get { return fGeneralComments; }
            set { SetPropertyValue<string>(nameof(GeneralComments), ref fGeneralComments, value); }
        }
        string fRunnerName;
        [Size(50)]
        public string RunnerName
        {
            get { return fRunnerName; }
            set { SetPropertyValue<string>(nameof(RunnerName), ref fRunnerName, value); }
        }
        string fDriverName;
        [Size(50)]
        public string DriverName
        {
            get { return fDriverName; }
            set { SetPropertyValue<string>(nameof(DriverName), ref fDriverName, value); }
        }
        string fDeliveryNote;
        [Size(50)]
        public string DeliveryNote
        {
            get { return fDeliveryNote; }
            set { SetPropertyValue<string>(nameof(DeliveryNote), ref fDeliveryNote, value); }
        }
        int fStatusID;
        public int StatusID
        {
            get { return fStatusID; }
            set { SetPropertyValue<int>(nameof(StatusID), ref fStatusID, value); }
        }
        string fSeal1Number;
        [Size(50)]
        public string Seal1Number
        {
            get { return fSeal1Number; }
            set { SetPropertyValue<string>(nameof(Seal1Number), ref fSeal1Number, value); }
        }
        string fSeal2Number;
        [Size(50)]
        public string Seal2Number
        {
            get { return fSeal2Number; }
            set { SetPropertyValue<string>(nameof(Seal2Number), ref fSeal2Number, value); }
        }
        int fWBTicket;
        public int WBTicket
        {
            get { return fWBTicket; }
            set { SetPropertyValue<int>(nameof(WBTicket), ref fWBTicket, value); }
        }
        string fLastUser;
        [Size(50)]
        public string LastUser
        {
            get { return fLastUser; }
            set { SetPropertyValue<string>(nameof(LastUser), ref fLastUser, value); }
        }
        int fShuttleID;
        public int ShuttleID
        {
            get { return fShuttleID; }
            set { SetPropertyValue<int>(nameof(ShuttleID), ref fShuttleID, value); }
        }
        Container_Packed fContainerPackedID;
        [Association(@"BookingReference_ProductDispatch_LteReferencesContainer_Packed")]
        public Container_Packed ContainerPackedID
        {
            get { return fContainerPackedID; }
            set { SetPropertyValue<Container_Packed>(nameof(ContainerPackedID), ref fContainerPackedID, value); }
        }
        int feFlag;
        public int eFlag
        {
            get { return feFlag; }
            set { SetPropertyValue<int>(nameof(eFlag), ref feFlag, value); }
        }
    }

}
