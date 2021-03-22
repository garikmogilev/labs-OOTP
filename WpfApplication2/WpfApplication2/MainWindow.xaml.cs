using System;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Threading;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(1)};
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if(mePlayer.Source != null)
            {
                if(mePlayer.NaturalDuration.HasTimeSpan)
                    LblStatus.Content =
                        $"{mePlayer.Position:hh\\:mm\\:ss} / {mePlayer.NaturalDuration.TimeSpan:hh\\:mm\\:ss}";
            }
            else
                LblStatus.Content = "No file selected...";
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
           mePlayer.Play();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Pause();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            mePlayer.Stop();
        }
    }
    
}