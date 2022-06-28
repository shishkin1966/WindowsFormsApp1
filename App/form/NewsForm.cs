using ClearArchitecture.SL;

namespace WindowsFormsApp1.App
{
    public partial class NewsForm : WindowsFormsApp1.App.BaseForm
    {
        public const string NAME = "NewsForm";
        private IModel<NewsForm> _model;

        public NewsForm()
        {
            SetModel(new NewsModel<NewsForm>(this));

            InitializeComponent();
        }

        public override string GetName()
        {
            return NAME;
        }

        public IModel<NewsForm> GetModel()
        {
            return _model;
        }

        public void SetModel(IModel<NewsForm> model)
        {
            base.RemoveLifecycleObserver(_model);
            _model = model;
            base.AddLifecycleObserver(_model);
        }
    }
}
