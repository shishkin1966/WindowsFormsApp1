using ClearArchitecture.SL;

namespace WindowsFormsApp1.App
{
    public class ModelObservable : BaseObservable
    {
        public const string NAME = "ModelObservable";

        public ModelObservable(): base(NAME)
        {
        }

        public override void OnChangeObservable(object obj)
        {
            base.OnChangeObservable(obj);

            var model = Program.SL.Models.GetModel(MainModel<MainForm>.NAME) as MainModel<MainForm>;
            if (model != null && model.IsValid())
            {
                model.Retrieve();
            }
        }
    }
}
