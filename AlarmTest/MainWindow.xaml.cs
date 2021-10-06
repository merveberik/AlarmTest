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

namespace AlarmTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static int counter = 0;
        Alarm alarm = new Alarm();
        bool changeStatus1, changeStatus2, changeStatus3;
        Alarms alarmDeneme = new Alarms();
        Alarms alarmDeneme2 = new Alarms();
        Alarms alarmDeneme3 = new Alarms();

        public MainWindow()
        {
            InitializeComponent();
            changeStatus1 = false;
            changeStatus2 = false;
            changeStatus3 = false;
            var timer = new System.Timers.Timer();
            timer.Interval = 500;
            timer.Elapsed += OnTimerElapsed;
            timer.Start();


            alarmDeneme.alarm = "Problem - 1";
            alarmDeneme.seviye = "HIGH";
            alarmDeneme.saat = DateTime.Now;
        }

        public class Alarms
        {
            public string alarm { get; set; }
            public string seviye { get; set; }
            public DateTime saat { get; set; }

        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            counter++;
            Console.WriteLine("Counter:" + counter);
            text1.Dispatcher.Invoke(() =>
            {
                text1.Text = "Counter:" + counter;
            });
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
            Alarm_Popup.IsOpen = true;
            alarmDeneme2.alarm = "Problem - 2";
            alarmDeneme2.seviye = "MIDDLE";
            alarmDeneme2.saat = DateTime.Now;
            grd.Items.Add(alarmDeneme2);
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
                counter = 0;
                Alarm_Popup.IsOpen = false;
            }
        }
    }
}
