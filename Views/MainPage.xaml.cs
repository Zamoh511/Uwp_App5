using DevExpress.Xpo;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uwp_App5.RapidCM_PGS_Dev;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Uwp_App5.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();

            PopulateGridControl();
            XPCollection<Order_OrderIn> Order_OrderIns = new XPCollection<Order_OrderIn>();
            Order_OrderIns = addRecords();
           

        }
        const string connectionString = @"XpoProvider=MSSqlServer;data source=DESKTOP-32QVBUV\SQL2017;user id=201619;password=pPqtKc19;initial catalog=RapidCM_PGS_Dev;Persist Security Info=true";
        public void PopulateGridControl()
        {
            //.textblock.Text = "Zamo";
            //myControl.dataGrid.ItemsSource = Order_OrderIns;
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            try
            {
                using (var uow = new UnitOfWork(inMemoryDAL))
                {
                    dxGrid.ItemsSource = new XPCollection<Library_Product>(uow);
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        

        public XPCollection<Order_OrderIn> addRecords()
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            XPCollection<Order_OrderIn> orders = new XPCollection<Order_OrderIn>();
            try
            {
                using (var uow = new UnitOfWork(inMemoryDAL))
                {
                    
                    orders = new XPCollection<Order_OrderIn>();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

            }
            return orders;
        }

        GridComboBox grid = new GridComboBox();
        
        public XPCollection<Library_Product> myList()
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            using (var uow = new UnitOfWork(inMemoryDAL))
            {
                return new XPCollection<Library_Product>(uow);
            }
        }
        private void Folder2_Click(object sender, RoutedEventArgs e)
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        //BindingHelper

        public class DataGridBoundColumn : DataGridTemplateColumn
        {
            public BindingBase Binding { get; set; }
            protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
            {
                var element = base.GenerateEditingElement(cell, dataItem);
                if (element != null && Binding != null)
                    element.SetBinding(ContentPresenter.DataContextProperty, Binding);
                return element;
            }

            protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
            {
                var element = base.GenerateElement(cell, dataItem);
                if (element != null && Binding != null)
                    element.SetBinding(ContentPresenter.DataContextProperty, Binding);//Error is here
                return element;
            }
        }


    }
}
