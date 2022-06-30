using ClearArchitecture.SL;

namespace WindowsFormsApp1.App
{
    public class FormsModelObservable : BaseObservable
    {
        public const string NAME = "FormsModelObservable";

        public FormsModelObservable() : base(NAME)
        {
        }

        public override void OnRegisterObserver(IObservableSubscriber subscriber)
        {
            base.OnRegisterObserver(subscriber);

            var model = Program.SL.Models.GetModel(FormsModel<Forms>.NAME) as FormsModel<Forms>;
            if (model != null)
            {
                model.Retrieve();
            }
        }

        public override void OnUnRegisterObserver(IObservableSubscriber subscriber)
        {
            base.OnUnRegisterObserver(subscriber);

            var model = Program.SL.Models.GetModel(FormsModel<Forms>.NAME) as FormsModel<Forms>;
            if (model != null)
            {
                model.Retrieve();
            }
        }

    }
}
