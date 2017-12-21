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
using System.Timers;

namespace VocaloidTimeSignal
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private Timer tm;
        private int timeSpan = 
            VocaloidTimeSignal.Properties.Settings.Default.interval;

        public MainWindow()
        {
            InitializeComponent();
            MySetup();
        }

        private void MySetup()
        {
            tm = new Timer();
            tm.Elapsed += Tm_Elapsed;
            tm.Interval = 500;
            tm.Start();
        }

        private void Tm_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(DateTime.Now.Minute % timeSpan == 0)
            {
                Player.Play(DateTime.Now);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btn1.IsEnabled = false;
            ApplicationTools.DoEvents();

            Player.Play(DateTime.Now);
            btn1.IsEnabled = true;
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            
            var stw = new SettingsWindow();
            stw.ShowDialog();
        }
    }
}
