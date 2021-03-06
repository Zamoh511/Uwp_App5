﻿using DevExpress.Xpo;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Uwp_App5.RapidCM_PGS_Dev;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Uwp_App5.Views
{
    public sealed partial class RecievesPage : Page, INotifyPropertyChanged
    {
        public RecievesPage()
        {

            InitializeComponent();
            insertSql();
            populateSQLcombo();
            PopulateCombobox();
            PopulateSupplierCombobox();
            PopulateTransCombobox();
            PopulateGridControl();
            PopulateImgCombobox();



        }
        const string connectionString = @"XpoProvider=MSSqlServer;data source=DESKTOP-32QVBUV\SQL2017;user id=201619;password=pPqtKc19;initial catalog=RapidCM_PGS_Dev;Persist Security Info=true";
        const string connectionString2 = @"data source=DESKTOP-32QVBUV\SQL2017;user id=201619;password=pPqtKc19;initial catalog=RapidCM_PGS_Dev;Persist Security Info=true";

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
                    pr.WBTicket = Convert.ToInt32(newWbTicket.Text);
                    uow.CommitChanges();
                    DisplayDialog();
                    PopulateGridControl();
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

        public void DeleteByKey(int ID)
        {
            using (var uow = new UnitOfWork())
            {
                var record = uow.GetObjectByKey<Order_OrderIn>(ID);
                uow.Delete(record);
                uow.CommitChanges();
            }
        }
        public void update(int key)
        {
            using (var uow = new UnitOfWork())
            {
                var record = uow.GetObjectByKey<Product_ProductReceive>(key);
                record.ContainerNo = newContainer.Text;
                record.WBTicket = Convert.ToInt32(newWbTicket.Text);
                record.TruckRegistration = newTruckReg.Text;
                record.DriverName = newDriver.Text;
                uow.CommitChanges();
            }
        }
        private async void DisplayDialog()
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
                    var list = order_OrderIns.Select(i => new { ID = (i.ID).ToString(), Name = i.OrderNo, JobCard = i.VesselIntakeID.JobCardNo }).ToList();
                    foreach (var item in list.Distinct())
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
        public void PopulateImgCombobox()
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            try
            {
                using (var uow = new UnitOfWork(inMemoryDAL))
                {
                    XPCollection<Library_Site> sites = new XPCollection<Library_Site>(uow);
                    var list = sites.Select(i => new { Logo = ImageFromBytes(i.Logo), i.Name }).ToList();
                    foreach (var item in list.Distinct())
                    {
                        ImgCombobox.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        public static BitmapImage ImageFromBytes(Byte[] bytes)
        {
            BitmapImage image = new BitmapImage();
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                stream.WriteAsync(bytes.AsBuffer());
                stream.Seek(0);
                image.SetSourceAsync(stream);
            }
            return image;
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

                    foreach (string item in list.Distinct())
                    {
                        SupplierComboBox.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
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
                    var list = Library_Transporters.Select(i => new { ID = (i.ID).ToString(), Name = i.Name }).ToList();
                    foreach (var item in list.Distinct())
                    {
                        ComboBoxItem comboItem = new ComboBoxItem();
                        comboItem.Content = item.Name;
                        comboItem.Tag = item.ID;
                        TransComboBox.Items.Add(comboItem);
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        public void PopulateGridControl()
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            try
            {
                using (var uow = new UnitOfWork(inMemoryDAL))
                {
                    dataGrid1.ItemsSource = new XPCollection<Product_ProductReceive>(uow);
                    
                    dxGrid1.ItemsSource= new XPCollection<Library_Product>(uow);

                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
       
        private void Click_Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
                using (var uow = new UnitOfWork(inMemoryDAL))
                {
                    XPQuery<Product_ProductReceive> items = new XPQuery<Product_ProductReceive>(uow);
                    Product_ProductReceive searchItem = items.FirstOrDefault(i => i.ID == Convert.ToInt32(((Windows.UI.Xaml.Controls.ContentControl)sender).Content.ToString()));
                    if (!String.IsNullOrEmpty(searchItem.ContainerNo))
                    {
                        newContainer.Text = (searchItem.ContainerNo).ToString();
                    }
                    if (!String.IsNullOrEmpty(searchItem.DriverName))
                    {
                        newDriver.Text = (searchItem.DriverName).ToString();
                    }
                    if (!String.IsNullOrEmpty(searchItem.TruckRegistration))
                    {
                        newTruckReg.Text = (searchItem.TruckRegistration).ToString();
                    }
                    newWbTicket.Text = (searchItem.WBTicket).ToString();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        public XPCollection<Library_Product> myList()
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            using (var uow = new UnitOfWork(inMemoryDAL))
            {

                return new XPCollection<Library_Product>(uow);
            }
          
        }
        public void UpdateRecord(int id)
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            using (var uow = new UnitOfWork(inMemoryDAL))
            {
                Product_ProductReceive product = uow.FindObject<Product_ProductReceive>(id);
            }
        }
        private void TransComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void SupplierComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DisplayDialog();
        }
        private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            using (var uow = new UnitOfWork(inMemoryDAL))
            {
                //XPQuery<Order_OrderIn> items = new XPQuery<Order_OrderIn>(uow);
                //Order_OrderIn searchItem = items.FirstOrDefault(i => i.OrderNo == (colorComboBox.SelectedValue.ToString()));
                //RecRemaining.Text = (searchItem.Quantity).ToString();
                //DisTotal.Text = (searchItem.Quantity).ToString();
                //RecTotal.Text = (searchItem.Quantity).ToString();
            }
        }

        private void search_QueryChanged(SearchBox sender, SearchBoxQueryChangedEventArgs args)
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            try
            {
                using (var uow = new UnitOfWork(inMemoryDAL))
                {
                    XPCollection<Order_OrderIn> orders = new XPCollection<Order_OrderIn>(uow);

                    if (orders != null)
                    {
                        colorComboBox.IsTextSearchEnabled = true;
                        colorComboBox.IsEditable = true;
                        var list = orders.Select(i => new { ID = (i.ID).ToString(), oName = i.OrderNo, JobCard = i.VesselIntakeID.JobCardNo }).ToList().Where(a => a.oName.ToUpper().Contains(search.QueryText.ToUpper())).ToString();
                        colorComboBox.ItemsSource = list.ToString();
                       

                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }
       
      
        public void insertSql()
        {
            try
            {
                string queryString = "Select * from Library_Supplier";
                using (SqlConnection connection = new SqlConnection(connectionString2))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    dataGrid2.Columns.Clear();
                    dataGrid2.AutoGenerateColumns = false;

                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        dataGrid2.Columns.Add(new DataGridTextColumn()
                        {
                            Header = table.Columns[i].ColumnName,
                            Binding = new Binding { Path = new PropertyPath("[" + i.ToString() + "]") }
                        });
                    }
                    var collection = new ObservableCollection<object>();
                    foreach (DataRow row in table.Rows)
                    {
                        collection.Add(row.ItemArray);
                    }
                    dataGrid2.ItemsSource = collection;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }

        //SqlComboBox
        public void populateSQLcombo()
        {
            try
            {
                string queryString = "Select * from Library_Supplier";
                using (SqlConnection connection = new SqlConnection(connectionString2))
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    for (int i = 0; i <= table.Rows.Count; i++)
                    {
                        ComboBoxItem boxItem = new ComboBoxItem();
                        boxItem.Tag = table.Rows[i]["ID"];
                        boxItem.Content = table.Rows[i]["Name"];
                        SqlComboBox.Items.Add(boxItem);                       
                    }


                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

    }
}
