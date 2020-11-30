using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DevExpress.Xpo;

using DevExpress.Security;
using DevExpress.XtraEditors;

using Windows.UI.Xaml.Controls;
using Uwp_App5.RapidCM_PGS_Dev;
using Windows.UI.Xaml;
using Syncfusion.UI.Xaml.Reports;
//using DevExpress.Persistent.BaseImpl.PermissionPolicy;

namespace Uwp_App5.Views
{
    public sealed partial class Account_LoginPage : Page, INotifyPropertyChanged
    {
        public Account_LoginPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ReportViewer.ReportPath = @"/Sample Reports/Company Sales";
                ReportViewer.ServiceAuthorizationToken = this.GenerateToken("http://reportserver.syncfusion.com/", "guest", "demo");
                ReportViewer.ReportServiceURL = @"http://reportserver.syncfusion.com/ReportService/api/Viewer";
                ReportViewer.ProcessingMode = ProcessingMode.Remote;
                ReportViewer.RefreshReport();

                //this.ReportViewer.ReportPath = "~/Resources/docs/sales-order-dtail.rdl";

                //this.ReportViewer.ReportServiceURL = @"https://demos.boldreports.com/javascript/#/report-viewer/product-catalog";
                //this.ReportViewer.RefreshReport();

            }
            catch(Exception ex)
            {
                var msg= ex.Message;
            }
           
        }

        public string GenerateToken(string serverUrl, string userName, string password)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                var content = new FormUrlEncodedContent(new[]
                {
         new KeyValuePair<string, string>("grant_type", "password"),
         new KeyValuePair<string, string>("username", zamo@rapiddev.co.za),
         new KeyValuePair<string, string>("password", Z@mokuhle511)
         });

                var result = client.PostAsync("/api/Token", content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                var token = JsonConvert.DeserializeObject<Token>(resultContent);

                return token.token_type + " " + token.access_token;
            }
        }

        public class Token
        {
            public string access_token { get; set; }

            public string token_type { get; set; }

            public string expires_in { get; set; }

            public string userName { get; set; }

            public string serverUrl { get; set; }

            public string password { get; set; }
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

        private void login_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

            //XpoTypesInfoHelper.GetXpoTypeInfoSource();
            //XafTypesInfo.Instance.RegisterEntity(typeof(Order_OrderIn));
            //XPObjectSpaceProvider osProvider = new XPObjectSpaceProvider(
            //@"integrated security=SSPI;pooling=false;data source=(localdb)\v11.0;initial catalog=MainDemo_", null);
            //IObjectSpace objectSpace = osProvider.CreateObjectSpace();
            //foreach (Order_OrderIn order in objectSpace.GetObjects<Order_OrderIn>())
            //{
            //    Console.WriteLine(order.OrderNo + "\t" + order.OrderDate);
            //}

        }
    }
}
