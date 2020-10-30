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

    public partial class Library_Transporter : XPLiteObject
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
        string fKeyContact;
        [Size(50)]
        public string KeyContact
        {
            get { return fKeyContact; }
            set { SetPropertyValue<string>(nameof(KeyContact), ref fKeyContact, value); }
        }
        string fKeyContactTelephone;
        [Size(50)]
        public string KeyContactTelephone
        {
            get { return fKeyContactTelephone; }
            set { SetPropertyValue<string>(nameof(KeyContactTelephone), ref fKeyContactTelephone, value); }
        }
        Library_TransporterType fTransporterTypeID;
        [Association(@"Library_TransporterReferencesLibrary_TransporterType")]
        public Library_TransporterType TransporterTypeID
        {
            get { return fTransporterTypeID; }
            set { SetPropertyValue<Library_TransporterType>(nameof(TransporterTypeID), ref fTransporterTypeID, value); }
        }
        [Association(@"AccessControlReferencesLibrary_Transporter")]
        public XPCollection<AccessControl> AccessControls { get { return GetCollection<AccessControl>(nameof(AccessControls)); } }
        [Association(@"AccessControlExitReferencesLibrary_Transporter")]
        public XPCollection<AccessControlExit> AccessControlExits { get { return GetCollection<AccessControlExit>(nameof(AccessControlExits)); } }
        [Association(@"BookingReference_ProductDispatchReferencesLibrary_Transporter")]
        public XPCollection<BookingReference_ProductDispatch> BookingReference_ProductDispatchs { get { return GetCollection<BookingReference_ProductDispatch>(nameof(BookingReference_ProductDispatchs)); } }
        [Association(@"BookingReference_ProductDispatch_LteReferencesLibrary_Transporter")]
        public XPCollection<BookingReference_ProductDispatch_Lte> BookingReference_ProductDispatch_Ltes { get { return GetCollection<BookingReference_ProductDispatch_Lte>(nameof(BookingReference_ProductDispatch_Ltes)); } }
        [Association(@"ContainerReferencesLibrary_Transporter")]
        public XPCollection<Container> Containers { get { return GetCollection<Container>(nameof(Containers)); } }
        [Association(@"Container_EmptyInReferencesLibrary_Transporter")]
        public XPCollection<Container_EmptyIn> Container_EmptyIns { get { return GetCollection<Container_EmptyIn>(nameof(Container_EmptyIns)); } }
        [Association(@"Container_EmptyOutReferencesLibrary_Transporter")]
        public XPCollection<Container_EmptyOut> Container_EmptyOuts { get { return GetCollection<Container_EmptyOut>(nameof(Container_EmptyOuts)); } }
        [Association(@"Container_FullInReferencesLibrary_Transporter")]
        public XPCollection<Container_FullIn> Container_FullIns { get { return GetCollection<Container_FullIn>(nameof(Container_FullIns)); } }
        [Association(@"Container_FullOutReferencesLibrary_Transporter")]
        public XPCollection<Container_FullOut> Container_FullOuts { get { return GetCollection<Container_FullOut>(nameof(Container_FullOuts)); } }
        [Association(@"ExpectedTrucksReferencesLibrary_Transporter")]
        public XPCollection<ExpectedTrucks> ExpectedTrucksCollection { get { return GetCollection<ExpectedTrucks>(nameof(ExpectedTrucksCollection)); } }
        [Association(@"Product_ProductDispatchReferencesLibrary_Transporter")]
        public XPCollection<Product_ProductDispatch> Product_ProductDispatchs { get { return GetCollection<Product_ProductDispatch>(nameof(Product_ProductDispatchs)); } }
        [Association(@"Product_ProductReceiveReferencesLibrary_Transporter")]
        public XPCollection<Product_ProductReceive> Product_ProductReceives { get { return GetCollection<Product_ProductReceive>(nameof(Product_ProductReceives)); } }
        [Association(@"ShuttleTrucksReferencesLibrary_Transporter")]
        public XPCollection<ShuttleTrucks> ShuttleTrucksCollection { get { return GetCollection<ShuttleTrucks>(nameof(ShuttleTrucksCollection)); } }
    }

}