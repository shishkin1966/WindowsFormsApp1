namespace WindowsFormsApp1.App
{
    public partial class SplashForm : WindowsFormsApp1.App.BaseForm
    {
        public SplashForm()
        {
            SetModel(new SplashModel<SplashForm>(this));

            InitializeComponent();
        }
    }
}
