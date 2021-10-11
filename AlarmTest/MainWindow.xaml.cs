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
        bool changeStatus1, changeStatus2, changeStatus3, changeStatus;
        Alarms alarmDeneme = new Alarms();
        Alarms alarmDeneme1 = new Alarms();
        Alarms alarmDeneme2 = new Alarms();
        Alarms alarmDeneme3 = new Alarms();
        int counterStat = 0;
        bool alarm1 = false, alarm2 = false;

        //string data;
        public MainWindow()
        {
            InitializeComponent();
            changeStatus = false;
            changeStatus2 = false;
            changeStatus3 = false;
            //var timer = new System.Timers.Timer();
            //timer.Interval = 500;
            //timer.Elapsed += OnTimerElapsed;
            //timer.Start();

            timer1.IsEnabled = true;
            timer1.Tick += new EventHandler(timerCount);
            timer1.Interval = TimeSpan.FromMilliseconds(1000);

        }
        private void timerCount(object sender, EventArgs e)
        {
            counter++;
            counterStat = 1;
            text1.Text = counter.ToString();
            if (grd.Items.Count > 0)
                grd2.Visibility = Visibility.Visible;

            else
            {
                grd2.Visibility = Visibility.Hidden;

            }

        }

        private void alarmi_datagride_yaz()
        {
            if (grd.Items.Cast<Alarms>().Any(t => t.Alarm_Id == 1))
            {
            }
            else
            {
                grd.Items.Add(alarmDeneme1);

            }
        }
        private void alarmi_datagride_yaz2()
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
            if (alarm1 == true)
            {
                Alarm_Popup.IsOpen = true;
                alarmDeneme1.Alarm_Id = 1;
                alarmDeneme1.alarm = this.Resources["2"].ToString();
                alarmDeneme1.seviye = "HIGH";
                alarmDeneme1.saat = DateTime.Now;

                alarmi_datagride_yaz();
            }
        }
        private void alarmlar2()
        {
            if (alarm2 == true)
            {

                Alarm_Popup.IsOpen = true;
                alarmDeneme2.Alarm_Id = 2;
                alarmDeneme2.alarm = this.Resources["15"].ToString();
                alarmDeneme2.seviye = "MIDDLE";
                alarmDeneme2.saat = DateTime.Now;

                alarmi_datagride_yaz2();

            }
        }
        private void alarm_dil_degistirme()
        {
            if (grd.Items.Count > 0)
            {
                grd.Items.Clear();
                if (alarm1 == true)
                {
                    alarmlar();
                }
                if (alarm2 == true)
                {
                    alarmlar2();
                }
            }
        }
        public class Alarms
        {
            public int Alarm_Id { get; set; }
            public string alarm { get; set; }
            public string seviye { get; set; }
            public DateTime saat { get; set; }
        }


        private void Start_Click1(object sender, RoutedEventArgs e)
        {
            alarm1 = true;
            //Alarm_Popup.IsOpen = true;
            alarmlar();
        }

        private void Start_Click2(object sender, RoutedEventArgs e)
        {
            alarm2 = true;
            //Alarm_Popup.IsOpen = true;
            alarmlar2();

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
            alarm1 = false;
        }

        private void Stop_Click2(object sender, RoutedEventArgs e)
        {
            alarm2 = false;
        }

        private void Stop_Click3(object sender, RoutedEventArgs e)
        {
            changeStatus3 = false;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (alarm1 == false)
            {
                if (grd.Items.Cast<Alarms>().Any(t => t.Alarm_Id == 1))
                {
                    grd.Items.Remove(alarmDeneme1);
                    //changeStatus3 = false;
                    //alarm_seviye = "HIGH";

                }

            }
            if (alarm2 == false)
            {
                if (grd.Items.Cast<Alarms>().Any(t => t.Alarm_Id == 2))
                {
                    grd.Items.Remove(alarmDeneme2);
                    //alarm_seviye = "HIGH";

                }

            }
            //if (changeStatus1 == false)
            //{
            //    counter = 0;
            //    grd.Items.Clear();
            //}
            //if (changeStatus2 == false)
            //{
            //    counter = 0;
            //    grd.Items.Clear();
            //}
            //if (changeStatus3 == false)
            //{
            //    counter = 0;
            //    grd.Items.Remove(alarmDeneme3);
            //}
            if (alarm1 == false & alarm2 == false)
            {
                Alarm_Popup.IsOpen = false;
            }
        }

        private void SetLanguageDictionary()
        {

            ResourceDictionary dict = new ResourceDictionary();
            changeStatus = true;
            switch (Thread.CurrentThread.CurrentCulture.ToString())
            {
                case "tr":
                    dict.Source = new Uri("..\\Diller\\Dictionary_Tr.xaml", UriKind.Relative);

                    break;

                case "en":
                    dict.Source = new Uri("..\\Diller\\Dictionary_En.xaml", UriKind.Relative);

                    break;

                default:
                    if (Properties.Settings.Default.dil_secimi == "tr")
                    {
                        dict.Source = new Uri("..\\Diller\\Dictionary_Tr.xaml", UriKind.Relative);

                    }

                    if (Properties.Settings.Default.dil_secimi == "en")
                    {
                        dict.Source = new Uri("..\\Diller\\Dictionary_En.xaml", UriKind.Relative);
                    }
                    break;
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
            alarm_dil_degistirme();
        }

        private void en_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.dil_secimi = "en";
            Properties.Settings.Default.Save();
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            SetLanguageDictionary();
            alarm_dil_degistirme();
        }
    }
}
