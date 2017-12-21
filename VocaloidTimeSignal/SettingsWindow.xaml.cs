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
using System.Windows.Shapes;

namespace VocaloidTimeSignal
{
    /// <summary>
    /// SettingsWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private int interval = VocaloidTimeSignal.Properties.Settings.Default.interval;
        private bool mikuTf = VocaloidTimeSignal.Properties.Settings.Default.lng_jp;
        private bool xinHuaTf = VocaloidTimeSignal.Properties.Settings.Default.lng_tw;

        public SettingsWindow()
        {
            InitializeComponent();
            UpdateControls();
            checkBoxTw.IsChecked = xinHuaTf;
            checkBoxJp.IsChecked = mikuTf;
            tBlockMin.Text = interval + "";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            VocaloidTimeSignal.Properties.Settings.Default.lng_tw = xinHuaTf;
            VocaloidTimeSignal.Properties.Settings.Default.lng_jp = mikuTf;
            VocaloidTimeSignal.Properties.Settings.Default.interval = interval;
            VocaloidTimeSignal.Properties.Settings.Default.Save();
        }

        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            xinHuaTf =  (bool)checkBoxTw.IsChecked;
            mikuTf = (bool)checkBoxJp.IsChecked;
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_up_Click(object sender, RoutedEventArgs e)
        {
            if (interval >= 90) return;
            interval += 10;
            UpdateControls();
        }

        private void btn_dw_Click(object sender, RoutedEventArgs e)
        {
            if (interval <= 10) return;
            interval -= 10;
            UpdateControls();
        }

        private void UpdateControls()
        {
            checkBoxTw.IsChecked = xinHuaTf;
            checkBoxJp.IsChecked = mikuTf;
            tBlockMin.Text = interval + "";
        }
    }
}
