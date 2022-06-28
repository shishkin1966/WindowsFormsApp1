using ClearArchitecture.SL;

namespace WindowsFormsApp1.App
{
    public class MainModel<T> : BaseModel<T> where T: MainForm
    {
        public const string NAME = "MainModel";

        public MainModel(MainForm form) : base(NAME, (IModelView<T>)form)
        {
        }

        public override string GetTitle()
        {
            return "";
        }

        public override void OnStart()
        {
            base.OnStart();

            var form = new SplashForm();
            form.ShowDialog();
        }
    }
}
