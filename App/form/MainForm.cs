using ClearArchitecture.SL;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public partial class MainForm : WindowsFormsApp1.App.BaseForm
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

        public bool IsValid()
        {
            if (GetState() != Lifecycle.ON_DESTROY && GetState() != Lifecycle.ON_CREATE) return true;
            return false;
        }

        private void OpenMenuItem_Click(object sender, System.EventArgs e)
        {
            var model = Program.SL.Models.GetModel(DocumentModel<DocumentForm>.NAME);
            if (model == null) {
                var form = new DocumentForm
                {
                    MdiParent = this
                };
                form.Dock = DockStyle.Fill;
                form.Show();
            } 
            else
            {
                ((DocumentModel<DocumentForm>)model).GetView().Focus();
            }
        }
    }
}
