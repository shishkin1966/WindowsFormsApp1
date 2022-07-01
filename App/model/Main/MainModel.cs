using ClearArchitecture.SL;
using System.Collections.Generic;

namespace WindowsFormsApp1.App
{
    public class MainModel<T> : BaseModel<T> where T: MainForm
    {
        public const string NAME = "MainModel";
        private readonly FormsModelObservable _observable = new FormsModelObservable();

        public FormsModelObservable FormsModelObservable
        {
            get
            {
                return _observable;
            }
        }

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

            Retrieve();

            Program.SL.Observable.RegisterObservable(FormsModelObservable);

            var form = new SplashForm();
            form.ShowDialog();
        }

        public override void OnDestroy()
        {
            Program.SL.Stop();
        }

        public void Retrieve()
        {
            List<string> list = Program.SL.Models.GetTitles();

            GetView().ListBox.Items.Clear();
            foreach (string item in list)
            {
                GetView().ListBox.Items.Add(item);
            }
        }
    }
}
