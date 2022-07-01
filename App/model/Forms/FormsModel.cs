using ClearArchitecture.SL;
using System.Collections.Generic;

namespace WindowsFormsApp1.App
{
    public class FormsModel<T> : BaseModel<T> where T : Forms
    {
        public const string NAME = "FormsModel";

        private readonly FormsModelObservable _observable = new FormsModelObservable();

        public FormsModelObservable FormsModelObservable
        {
            get
            {
                return _observable;
            }
        }

        public FormsModel(Forms form) : base(NAME, (IModelView<T>)form)
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
        }

        public override void OnDestroy()
        {
            Program.SL.Observable.UnRegisterObservable(FormsModelObservable);
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
