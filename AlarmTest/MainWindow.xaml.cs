using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace AlarmTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter = 0, counter2 = 0;
        DispatcherTimer timer1 = new DispatcherTimer();

        Alarm alarm = new Alarm();
        bool changeStatus1, changeStatus2, changeStatus3;
        Alarms alarmDeneme = new Alarms();
        Alarms alarmDeneme2 = new Alarms();
        Alarms alarmDeneme3 = new Alarms();
        int counterStat = 0;
        bool speed_hata1 = false;
        string alarm_seviye;
        string alarm_text;

        public MainWindow()
        {
            InitializeComponent();
            changeStatus1 = false;
            changeStatus2 = false;
            changeStatus3 = false;
            //var timer = new System.Timers.Timer();
            //timer.Interval = 500;
            //timer.Elapsed += OnTimerElapsed;
            //timer.Start();

            timer1.IsEnabled = true;
            timer1.Tick += new EventHandler(timerCount);
            timer1.Interval = TimeSpan.FromMilliseconds(1000);

            alarmDeneme.Alarm_Id = 2;
            alarmDeneme.alarm = "alarm";

            //System.Windows.MessageBox.Show(this.Resources["Hız sensör Hata"].ToString());
            alarmDeneme.seviye = "HIGH";
            alarmDeneme.saat = DateTime.Now;
        }
        private void timerCount(object sender, EventArgs e)
        {
            counter++;
            counterStat = 1;
            text1.Text = counter.ToString();
            if (grd.Items.Count > 0)
            {

                grd.Visibility = Visibility.Visible;

            }

            else
                grd.Visibility = Visibility.Hidden;

        }

        private void alarmi_datagride_yaz()
        {
            if (grd.Items.Cast<Alarms>().Any(t => t.Alarm_Id == 2))
            {
            }
            else
            {
                grd.Items.Add(alarmDeneme2);
            }
        }
        private void alarmlar()
        {
            if (speed_hata1 == true)
            {

                Alarm_Popup.IsOpen = true;
                alarmDeneme2.Alarm_Id = 2;
                alarmDeneme2.alarm = "Hız sensör Hata";
                alarmDeneme2.seviye = "MIDDLE";
                alarmDeneme2.saat = DateTime.Now;

                alarmi_datagride_yaz();


            }
        }
        public class Alarms
        {
            public int Alarm_Id { get; set; }
            public string alarm { get; set; }
            public string seviye { get; set; }
            public DateTime saat { get; set; }
            public bool speed_hata { get; set; }
        }


        private void Start_Click1(object sender, RoutedEventArgs e)
        {
            changeStatus1 = true;
            Alarm_Popup.IsOpen = true;
            grd.Items.Add(alarmDeneme);

        }

        private void Start_Click2(object sender, RoutedEventArgs e)
        {

            changeStatus2 = true;
            speed_hata1 = true;
            alarmlar();
            //Alarm_Popup.IsOpen = true;
            //alarmDeneme2.alarm = "CVY3 Hız sensör Hata";
            //alarmDeneme2.seviye = "MIDDLE";
            //alarmDeneme2.saat = DateTime.Now;
            //grd.Items.Add(alarmDeneme2);
        }

        private void Start_Click3(object sender, RoutedEventArgs e)
        {
            changeStatus3 = true;
            Alarm_Popup.IsOpen = true;
            alarmDeneme3.alarm = "Problem - 3";
            alarmDeneme3.seviye = "LOW";
            alarmDeneme3.saat = DateTime.Now;
            grd.Items.Add(alarmDeneme3);
        }

        private void Stop_Click1(object sender, RoutedEventArgs e)
        {
            changeStatus1 = false;
        }

        private void Stop_Click2(object sender, RoutedEventArgs e)
        {
            changeStatus2 = false;
        }

        private void Stop_Click3(object sender, RoutedEventArgs e)
        {
            changeStatus3 = false;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (changeStatus1 == false)
            {
                counter = 0;
                grd.Items.Remove(alarmDeneme);
            }
            if (changeStatus2 == false)
            {
                counter = 0;
                grd.Items.Remove(alarmDeneme2);
            }
            if (changeStatus3 == false)
            {
                counter = 0;
                grd.Items.Remove(alarmDeneme3);
            }
            if (changeStatus1 == false & changeStatus2 == false & changeStatus3 == false)
            {
                Alarm_Popup.IsOpen = false;
            }
        }
        private void SetLanguageDictionary()
        {

            ResourceDictionary dict = new ResourceDictionary();


            if (Properties.Settings.Default.dil_secimi == "tr")
            {
                dict.Source = new Uri("..\\Diller\\Dictionary_Tr.xaml", UriKind.Relative);

            }

            if (Properties.Settings.Default.dil_secimi == "en")
            {
                dict.Source = new Uri("..\\Diller\\Dictionary_En.xaml", UriKind.Relative);
            }


            this.Resources.MergedDictionaries.Add(dict);
        }

        private void tr_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.dil_secimi = "tr";
            Properties.Settings.Default.Save();
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("tr");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            SetLanguageDictionary();
        }

        private void en_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.dil_secimi = "en";
            Properties.Settings.Default.Save();
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            SetLanguageDictionary();
        }
    }
}
