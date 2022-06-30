using ClearArchitecture.SL;
using System.Collections.Generic;

namespace WindowsFormsApp1.App
{
    public class FormsModel<T> : BaseModel<T>, IObservable where T : Forms
    {
        public const string NAME = "FormsModel";

        private readonly FormsModelObservable _observable = new FormsModelObservable();

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

            Program.SL.Observable.RegisterObservable(_observable);
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

        void IObservable.AddObserver(IObservableSubscriber subscriber)
        {
            if (subscriber == null) return;

            _observable.AddObserver(subscriber);
        }

        List<IObservableSubscriber> IObservable.GetObservers()
        {
            return _observable.GetObservers();
        }

        void IObservable.OnChangeObservable(object obj)
        {
            _observable.OnChangeObservable(obj);
        }

        void IObservable.OnRegisterFirstObserver()
        {
            //
        }

        void IObservable.OnUnRegisterLastObserver()
        {
            //
        }

        void IObservable.RemoveObserver(IObservableSubscriber subscriber)
        {
            if (subscriber == null) return;

            _observable.RemoveObserver(subscriber);
        }

        public IObservableSubscriber GetObserver(string name)
        {
            return _observable.GetObserver(name);
        }

        public void OnRegisterObserver(IObservableSubscriber subscriber)
        {
            Retrieve();
        }

        public void OnUnRegisterObserver(IObservableSubscriber subscriber)
        {
            Retrieve();
        }
    }
}
