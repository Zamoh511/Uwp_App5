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
using Uwp_App5.RapidCM_PGS_Dev;
namespace Uwp_App5.RapidCM_PGS_Dev
{
    public partial class RapidCM_PGS_DevUnitOfWork : UnitOfWork
    {
        public RapidCM_PGS_DevUnitOfWork() : base() { }
        public RapidCM_PGS_DevUnitOfWork(DevExpress.Xpo.Metadata.XPDictionary dictionary) : base(dictionary) { }
        public RapidCM_PGS_DevUnitOfWork(IDataLayer layer, params IDisposable[] disposeOnDisconnect) : base(layer, disposeOnDisconnect) { }
        public RapidCM_PGS_DevUnitOfWork(IObjectLayer layer, params IDisposable[] disposeOnDisconnect) : base(layer, disposeOnDisconnect) { }
    }
}
namespace Microsoft.Extensions.DependencyInjection
{
    public static class RapidCM_PGS_DevXpoServiceCollectionExtensions
    {
        public static IServiceCollection AddRapidCM_PGS_DevAsXpoDefaultUnitOfWork(this IServiceCollection serviceCollection, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultUnitOfWork(useDataLayerAsSingletone, optionsBuilder);
        }
        public static IServiceCollection AddRapidCM_PGS_DevAsXpoDefaultSession(this IServiceCollection serviceCollection, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultSession(useDataLayerAsSingletone, optionsBuilder);
        }
        public static IServiceCollection AddRapidCM_PGS_DevUnitOfWork(this IServiceCollection serviceCollection, bool useDataLayerAsSingletone = true, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoCustomSession<RapidCM_PGS_DevUnitOfWork>(useDataLayerAsSingletone, optionsBuilder);
        }
        public static IServiceCollection AddRapidCM_PGS_DevXpoDefaultDataLayer(this IServiceCollection serviceCollection, ServiceLifetime lifetime, Action<DataLayerOptionsBuilder> customDataLayerOptionsBuilder = null)
        {
            Action<DataLayerOptionsBuilder> optionsBuilder = CreateDataLayerOptionsBuilder(customDataLayerOptionsBuilder);
            return serviceCollection.AddXpoDefaultDataLayer(lifetime, customDataLayerOptionsBuilder);
        }
        static Action<DataLayerOptionsBuilder> CreateDataLayerOptionsBuilder(Action<DataLayerOptionsBuilder> injectCustomDataLayerOptionsBuilder)
        {
            return (options) =>
            {
                options
                .UseConnectionString(ConnectionHelper.ConnectionString)
                .UseEntityTypes(ConnectionHelper.GetPersistentTypes());
                if (injectCustomDataLayerOptionsBuilder != null)
                {
                    injectCustomDataLayerOptionsBuilder(options);
                }
            };
        }
    }
}