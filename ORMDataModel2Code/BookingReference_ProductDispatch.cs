using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace Uwp_App5.RapidCM_PGS_Dev
{

    public partial class BookingReference_ProductDispatch
    {
        public BookingReference_ProductDispatch(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}
