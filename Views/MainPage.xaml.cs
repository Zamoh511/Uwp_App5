using DevExpress.Xpo;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Uwp_App5.RapidCM_PGS_Dev;
using Windows.UI.Xaml.Controls;

namespace Uwp_App5.Views
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            InitializeComponent();

            PopulateGridControl();
            
        }
        const string connectionString = @"XpoProvider=MSSqlServer;data source=DESKTOP-32QVBUV\SQL2017;user id=201619;password=pPqtKc19;initial catalog=RapidCM_PGS_Dev;Persist Security Info=true";
        public void PopulateGridControl()
        {
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
    }
}
