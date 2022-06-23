using ClearArchitecture.SL;

namespace WindowsFormsApp1.App
{
    public partial class MainForm : WindowsFormsApp1.App.BaseForm, IModelView<MainForm>
    {
        private IModel<MainForm> _model;

        public MainForm()
        {
            SetModel(new MainModel<MainForm>(this));

            InitializeComponent();
        }

        public override string GetName()
        {
            return "MainForm";
        }

        public IModel<MainForm> GetModel()
        {
            return _model;
        }

        public void SetModel(IModel<MainForm> model)
        {
            base.RemoveLifecycleObserver(_model);
            _model = model;
            base.AddLifecycleObserver(_model);
        }

        private void ExitMenuItem_Click(object sender, System.EventArgs e)
        {
            Program.SL.Stop();
        }
    }
}
