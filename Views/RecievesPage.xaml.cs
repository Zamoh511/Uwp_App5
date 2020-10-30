using DevExpress.Xpo;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Uwp_App5.RapidCM_PGS_Dev;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Uwp_App5.Views
{
    public sealed partial class RecievesPage : Page, INotifyPropertyChanged
    {
        public RecievesPage()
        {
            InitializeComponent();
            PopulateCombobox();
            PopulateSupplierCombobox();
            PopulateTransCombobox();

        }
        const string connectionString = @"XpoProvider=MSSqlServer;data source=DESKTOP-32QVBUV\SQL2017;user id=201619;password=pPqtKc19;initial catalog=RapidCM_PGS_Dev;Persist Security Info=true";

        ObservableCollection<Order_OrderIn> Order_OrderIns = new ObservableCollection<Order_OrderIn>();

        private void commitButton_Click(object sender, RoutedEventArgs e)
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);

            try
            {
                using (var uow = new UnitOfWork(inMemoryDAL))
                {

                    XPQuery<Order_OrderIn> items = new XPQuery<Order_OrderIn>(uow);
                    Order_OrderIn searchItem = items.FirstOrDefault(i => i.OrderNo == (colorComboBox.SelectedValue.ToString()));

                    XPQuery<Library_Supplier> L_items = new XPQuery<Library_Supplier>(uow);
                    Library_Supplier L_SearchItem = L_items.FirstOrDefault(i => i.Name == (SupplierComboBox.SelectedValue.ToString()));

                    //dataGrid1.ItemsSource = new XPCollection<Product_ProductReceive>(uow);
                    XPQuery<Library_Transporter> Trans_items = new XPQuery<Library_Transporter>(uow);
                    Library_Transporter LT_SearchItem = Trans_items.FirstOrDefault(i => i.Name == (TransComboBox.SelectedValue.ToString()));

                    var pr = new Product_ProductReceive(uow);
                    pr.SupplierID = L_SearchItem;
                    pr.RecOrderID = searchItem;
                    pr.TransporterID = LT_SearchItem;
                    pr.DateModified = DateTime.Now;
                    pr.DriverName = newDriver.Text;
                    pr.TruckRegistration = newTruckReg.Text;
                    pr.ContainerNo = newContainer.Text;
                    //pr.ArrivalDate = datePacked.DateTime;
                    pr.WBTicket = Convert.ToInt32(newWbTicket.Text);
                    uow.CommitChanges();

                    DisplayNoWifiDialog();

                    newContainer.Text = "";
                    newWbTicket.Text = "";
                    newTruckReg.Text = "";
                    newDriver.Text = "";

                }
            }
            catch (Exception ex)
            {
                Name = ex.Message;
            }

        }

        private async void DisplayNoWifiDialog()
        {
            ContentDialog Dialog = new ContentDialog
            {
                Title = "Confimation.",
                Content = "Save",
                CloseButtonText = "Ok"
            };
            ContentDialogResult result = await Dialog.ShowAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }



        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        public void populateRecievesGrid()
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);

            using (var uow = new UnitOfWork(inMemoryDAL))
            {
                try
                {
                    ObservableCollection<Product_ProductReceive> ProductReceives = new ObservableCollection<Product_ProductReceive>();
                    //prGrid1.ItemsSource = ProductReceives.Where(x => x.ArrivalDate == DateTime.Today).ToList();
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }

            }
        }
        public void PopulateCombobox()
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);

            try
            {
                using (var uow = new UnitOfWork(inMemoryDAL))
                {

                    XPCollection<Order_OrderIn> order_OrderIns = new XPCollection<Order_OrderIn>(uow);
                    var list = order_OrderIns.Select(x => x.OrderNo).ToList();
                    //colorComboBox.Items.Clear();
                    foreach (string item in list.Distinct())
                    {
                        colorComboBox.Items.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        public void PopulateSupplierCombobox()
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);

            try
            {
                using (var uow = new UnitOfWork(inMemoryDAL))
                {

                    XPCollection<Library_Supplier> Library_Suppliers = new XPCollection<Library_Supplier>(uow);
                    var list = Library_Suppliers.Select(x => x.Name).ToList();
                    //colorComboBox.Items.Clear();
                    foreach (string item in list.Distinct())
                    {
                        SupplierComboBox.Items.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
        public void PopulateTransCombobox()
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);

            try
            {
                using (var uow = new UnitOfWork(inMemoryDAL))
                {

                    XPCollection<Library_Transporter> Library_Transporters = new XPCollection<Library_Transporter>(uow);
                    var list = Library_Transporters.Select(x => x.Name).ToList();
                    //colorComboBox.Items.Clear();
                    foreach (string item in list.Distinct())
                    {
                        TransComboBox.Items.Add(item);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }


        private void TransComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }
        private void SupplierComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }
        //orderComboBox
        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            using (var uow = new UnitOfWork(inMemoryDAL))
            {

                XPQuery<Order_OrderIn> items = new XPQuery<Order_OrderIn>(uow);
                Order_OrderIn searchItem = items.FirstOrDefault(i => i.OrderNo == (colorComboBox.SelectedValue.ToString()));
                RecRemaining.Text = (searchItem.Quantity).ToString();
                DisTotal.Text = (searchItem.Quantity).ToString();
                RecTotal.Text = (searchItem.Quantity).ToString();
            }
        }
        
    }
}
