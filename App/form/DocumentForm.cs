using ClearArchitecture.SL;

namespace WindowsFormsApp1.App
{
    public partial class DocumentForm : WindowsFormsApp1.App.BaseForm
    {
        private IModel<DocumentForm> _model;

        public DocumentForm()
        {
            SetModel(new DocumentModel<DocumentForm>(this));

            InitializeComponent();
        }

        public override string GetName()
        {
            return "DocumentForm";
        }

        public IModel<DocumentForm> GetModel()
        {
            return _model;
        }

        public void SetModel(IModel<DocumentForm> model)
        {
            base.RemoveLifecycleObserver(_model);
            _model = model;
            base.AddLifecycleObserver(_model);
        }

        public bool IsValid()
        {
            if (GetState() != Lifecycle.ON_DESTROY && GetState() != Lifecycle.ON_CREATE) return true;
            return false;
        }
    }
}
