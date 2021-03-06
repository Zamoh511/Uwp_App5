﻿using DevExpress.Compatibility.System.Windows.Forms;
using DevExpress.Core.Extensions;
using DevExpress.UI.Xaml.Gauges;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.UI.Xaml.Controls;
using System.Timers;
using Windows.UI.Xaml;
using System.Net;
using System.IO;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Media;
using System.Collections.Generic;

namespace Uwp_App5.Views
{
    public sealed partial class DispatchPage : Page, INotifyPropertyChanged
    {
        public static ArcScale arcScales = new ArcScale();
        public static ArcScaleMarker arcScaleMarker = new ArcScaleMarker();
        public static ArcScaleNeedle arcScaleNeedle = new ArcScaleNeedle();
        public static ArcScaleRangeBar arcScaleRangeBar = new ArcScaleRangeBar();
        public DispatchPage()
        {
            InitializeComponent();
            SetFakeData();
            
        }
        private int _airTemp;
        public int AirTemp
        {
            get
            {
                return _airTemp;
            }
            set
            {
                _airTemp = value;
                OnPropertyChanged();
            }
        }

        private BitmapImage fMainImage;
        public BitmapImage MainImage
        {
            get { return fMainImage; }
            set
            {
                if (fMainImage != value)
                {
                    fMainImage = value;
                    OnPropertyChanged("MainImage");
                }
            }
        }

        //http://192.168.1.100/cgi-bin/viewer/video.jpg

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }


        private void SetFakeData()
        {
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.5);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            Random random = new Random();
            AirTemp = random.Next(0, 12);

            //PictureBox.UriSource =  new Uri("http://192.168.1.100/cgi-bin/viewer/video.jpg");
            BitmapImage bitmap = new BitmapImage();
            
            bitmap.UriSource= new Uri("http://192.168.1.100/cgi-bin/viewer/video.jpg");
            PictureBox2.Source = bitmap;

            try
            {
                //MainImage.Equals(new Uri("http://192.168.1.100/cgi-bin/viewer/video.jpg"));
                //PictureBox.UriSource = MainImage;
                //MainImage = new Uri("http://192.168.1.100/cgi-bin/viewer/video.jpg");
                //PictureBox.UriSource = MainImage.UriSource;
                //BitmapImage bitmapImage = new BitmapImage();
                //bitmapImage.UriSource = new Uri("http://192.168.1.100/cgi-bin/viewer/video.jpg");
                //MainImage = bitmapImage;
                //PictureBox2 = MainImage;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

            }


        }

        //public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return;
            }

            storage = value;
            OnPropertyChanged(propertyName);
        }

        //private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));        

        public void updateGauge()
        {

            arcScales.StartValue = 0;
            arcScales.EndValue = 12;
            arcScales.StartAngle = -90;
            arcScales.EndAngle = 270;
            arcScales.MajorIntervalCount = 12;
            arcScales.MinorIntervalCount = 5;
           
            arcScaleMarker.Value = 5;

            arcScaleNeedle.Value = 4;
            arcScaleNeedle.Value =10;
           
            arcScaleRangeBar.AnchorValue = 8;
            arcScaleRangeBar.Value = 2;
            //Add Items
            arcScales.RangeBars.Add(arcScaleRangeBar);
            arcScales.Needles.Add(arcScaleNeedle);
            arcScales.Markers.Add(arcScaleMarker);

            gauge1.Scales.Add(arcScales);
            arcScaleMarker.Value = 10;
            //System.Threading.Thread.Sleep(5000);
            arcScaleMarker.Value = 1;

        }
            
        public void updateLineGauge()
        {

           
            LinearScale linearScale = new LinearScale();
           
            linearScale.StartValue = 20;
            linearScale.EndValue = 100;
            linearScale.MajorIntervalCount =20;
            //linearScale.MinorIntervalCount = 5;

            LinearScaleLevelBar linearScaleLevelBar = new LinearScaleLevelBar();
            linearScaleLevelBar.Value = 20;

            LinearScaleRange linearScaleRange = new LinearScaleRange();
            linearScaleRange.StartValue = 0;
            linearScaleRange.EndValue = 100;


            //Add Items
            linearScale.LevelBars.Add(linearScaleLevelBar);
            linearScale.Ranges.Add(linearScaleRange);


            LineGauge.Scales.Add(linearScale);

        }
        //public Image getImage()
        //{
        //    //WebClient wc = new WebClient();
        //    //byte[] bytes = wc.DownloadData("http://192.168.1.100/cgi-bin/viewer/video.jpg");
        //    //MemoryStream ms = new MemoryStream(bytes);
        //    //System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
        //    //return img;
        //}
        private void Load_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            updateGauge();
        }

        private void Load1_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            updateLineGauge();
        }

        private void Load2_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
           
        }



    }
}
