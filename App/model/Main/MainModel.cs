using ClearArchitecture.SL;
using System.Threading;

namespace WindowsFormsApp1.App
{
    public class MainModel<T> : BaseModel<T> where T: MainForm
    {
        public const string NAME = "MainModel";
        private SplashForm form;

        public MainModel(MainForm form) : base(NAME, (IModelView<T>)form)
        {
        }

        public override void OnStart()
        {
            base.OnStart();

            form = new SplashForm();
            form.Show();
        }
    }
}
