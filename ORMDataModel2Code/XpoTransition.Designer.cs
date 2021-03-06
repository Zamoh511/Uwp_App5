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

    public partial class XpoTransition : XPCustomObject
    {
        Guid fOid;
        [Key(true)]
        public Guid Oid
        {
            get { return fOid; }
            set { SetPropertyValue<Guid>(nameof(Oid), ref fOid, value); }
        }
        string fCaption;
        public string Caption
        {
            get { return fCaption; }
            set { SetPropertyValue<string>(nameof(Caption), ref fCaption, value); }
        }
        XpoState fSourceState;
        [Association(@"XpoTransitionReferencesXpoState")]
        public XpoState SourceState
        {
            get { return fSourceState; }
            set { SetPropertyValue<XpoState>(nameof(SourceState), ref fSourceState, value); }
        }
        XpoState fTargetState;
        [Association(@"XpoTransitionReferencesXpoState1")]
        public XpoState TargetState
        {
            get { return fTargetState; }
            set { SetPropertyValue<XpoState>(nameof(TargetState), ref fTargetState, value); }
        }
        int fIndex;
        public int Index
        {
            get { return fIndex; }
            set { SetPropertyValue<int>(nameof(Index), ref fIndex, value); }
        }
        bool fSaveAndCloseView;
        public bool SaveAndCloseView
        {
            get { return fSaveAndCloseView; }
            set { SetPropertyValue<bool>(nameof(SaveAndCloseView), ref fSaveAndCloseView, value); }
        }
    }

}
