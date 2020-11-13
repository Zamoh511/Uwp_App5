using DevExpress.Xpo;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Uwp_App5.RapidCM_PGS_Dev;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Uwp_App5
{
    public sealed partial class GridComboBox : UserControl
    {
        public GridComboBox()
        {
            this.InitializeComponent();
            PopulateGridControl();
            populateGrid();
        }

        const string connectionString = @"XpoProvider=MSSqlServer;data source=DESKTOP-32QVBUV\SQL2017;user id=201619;password=pPqtKc19;initial catalog=RapidCM_PGS_Dev;Persist Security Info=true";
        public string textblock
        {
            get { return (string)GetValue(textblockProperty); }
            set { SetValue(textblockProperty, value); }

        }

        public DependencyProperty textblockProperty = DependencyProperty.Register("textblock", typeof(string), typeof(GridComboBox),null);
        public ImageSource imageSource
        {
            get { return (ImageSource)GetValue(imageSourceProperty); }
            set { SetValue(imageSourceProperty, typeof(GridComboBox)); }

        }

        public  DependencyProperty imageSourceProperty = DependencyProperty.Register("imageSource", typeof(ImageSource), typeof(GridComboBox), null);

        public DataGrid dataGrid
        {
            get { return (DataGrid)GetValue(DataGridProperty); }
            set { SetValue(DataGridProperty, typeof(GridComboBox)); }

        }

        public static readonly DependencyProperty DataGridProperty = DependencyProperty.Register("dataGrid", typeof(DataGrid), typeof(GridComboBox), null);


        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public void populateGrid()
        {
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            try
            {
                using (var uow = new UnitOfWork(inMemoryDAL))
                {
                    XPCollection<Order_OrderIn> orders = new XPCollection<Order_OrderIn>(uow);
                    MyGrid.ItemsSource = orders;
                    MyGrid.Width = 280;
                }
            }
            catch (Exception ex)
            {
                var MSG = ex.Message;
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
                    MyGrid.ItemsSource = orders;
                    if (orders != null)
                    {
                        
                        var list = orders.Where(a => a.OrderNo.ToUpper().Contains(search.QueryText.ToUpper()));
                        MyGrid.ItemsSource = list;
                        MyGrid.Height = 400;
                        MyGrid.Width = 600;
                        

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
            
            textblock = "Testing";
            var inMemoryDAL = XpoDefault.GetDataLayer(connectionString, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);
            try
            {
                using (var uow = new UnitOfWork(inMemoryDAL))
                {
                   
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        private void MyGrid_SelectionChanged(object sender, DevExpress.UI.Xaml.Grid.SelectedItemChangedEventArgs e)
        {
            //var item = e;
            int id = ((Uwp_App5.RapidCM_PGS_Dev.Order_OrderIn)e.NewItem).ID;

            MyGrid.Height = 100;
            MyGrid.Width = 280;
        }
    }
}
