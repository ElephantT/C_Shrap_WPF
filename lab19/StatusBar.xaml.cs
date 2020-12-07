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
using System.Threading;
using System.ComponentModel;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab19
{
    // HorizontalAlignment="Left" 
    // это чтобы сделать statusbar адекватным
    public partial class StatusBar : Window
    {
        public StatusBar()
        {
            InitializeComponent();
        }

        private void StartProcess(object sender, EventArgs e)
        {
            BackgroundWorker process = new BackgroundWorker();
            process.WorkerReportsProgress = true;
            process.DoWork += Process;
            process.ProgressChanged += ChangeStatus;
            process.RunWorkerAsync();
        }

        private void Process(object sender, EventArgs e)
        {
            for (int i = 0; i < 501; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(11);
            }
        }

        void ChangeStatus(object sender, ProgressChangedEventArgs e)
        {
            Status.Value = e.ProgressPercentage;
        }

    }
}
