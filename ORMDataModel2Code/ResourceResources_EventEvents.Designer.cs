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

    public partial class ResourceResources_EventEvents : XPBaseObject
    {
        Event fEvents;
        [Indexed(@"Resources", Name = @"iEventsResources_ResourceResources_EventEvents", Unique = true)]
        [Association(@"ResourceResources_EventEventsReferencesEvent")]
        public Event Events
        {
            get { return fEvents; }
            set { SetPropertyValue<Event>(nameof(Events), ref fEvents, value); }
        }
        Resource fResources;
        [Association(@"ResourceResources_EventEventsReferencesResource")]
        public Resource Resources
        {
            get { return fResources; }
            set { SetPropertyValue<Resource>(nameof(Resources), ref fResources, value); }
        }
        Guid fOID;
        [Key(true)]
        public Guid OID
        {
            get { return fOID; }
            set { SetPropertyValue<Guid>(nameof(OID), ref fOID, value); }
        }
    }

}
