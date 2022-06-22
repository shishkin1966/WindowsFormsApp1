namespace WindowsFormsApp1.App
{
    public partial class MainForm : WindowsFormsApp1.App.BaseForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

         public override string GetName()
        {
            return "MainForm";
        }

        private void ExitMenuItem_Click(object sender, System.EventArgs e)
        {
            Program.SL.Stop();
        }
    }
}
