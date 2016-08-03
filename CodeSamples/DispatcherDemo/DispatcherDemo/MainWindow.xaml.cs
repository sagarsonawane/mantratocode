using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace DispatcherDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private delegate void CalculateTimeElapsed();
        DateTime currentDateTime;
        static int count = 0;

        private void btnLong_Click(object sender, RoutedEventArgs e)
        {
            btnLong.IsEnabled = false;
            currentDateTime = DateTime.Now;

            Thread longRunningThread = new Thread(new ThreadStart(delegate () { Thread.Sleep(10000); Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new CalculateTimeElapsed(PostLongRunningTasks)); }));
            longRunningThread.Start();
        }

        private void PostLongRunningTasks()
        {
            txtInfo.Text = "Total time elapsed required to finish the task is : " + (DateTime.Now - currentDateTime);
            btnLong.IsEnabled = true;
        }

        private void btnCurrent_Click(object sender, RoutedEventArgs e)
        {
            txtCurrent.Text = "Above button is clicked " + ++count + " times";
        }
    }
}
