using ClearArchitecture.SL;
using System.Threading;

namespace WindowsFormsApp1.App
{
    public partial class SplashForm : WindowsFormsApp1.App.BaseForm
    {
        public SplashForm()
        {
            SetModel(new SplashModel<SplashForm>(this));

            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Thread.Sleep(300);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.ProgressBar.Value += 1;
            if (this.ProgressBar.Value == this.ProgressBar.Maximum)
            {
                this.Close();
            }
            else
            {
                BackgroundWorker.RunWorkerAsync();
            }
        }
    }
}
