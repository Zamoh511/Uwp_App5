using DevExpress.Compatibility.System.Windows.Forms;
using DevExpress.Core.Extensions;
using DevExpress.UI.Xaml.Gauges;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Windows.UI.Xaml.Controls;
using System.Timers;

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

            SetTimer();
           
            //aTimer.Stop();
            //aTimer.Dispose();
         //   sAMPLE
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
        private static System.Timers.Timer aTimer;
        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(5000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

           // DispatchPage mydispath = new DispatchPage();
            updateGauge2();
           // updateGauge2();
        }

        public static void updateGauge2()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 10);

            arcScaleMarker.Value = randomNumber;// random.g(1,10);
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
            updateGauge2();
        }
    }
}
