using ClearArchitecture.SL;

namespace WindowsFormsApp1.App
{
    public class ModelObserver : IObserver
    {
        public const string NAME = "ModelObserver";

        public ModelObserver()
        {
        }

        public string GetName()
        {
            return NAME;
        }

        public void OnChangeObservable(object obj)
        {
            var model = Program.SL.Models.GetModel(MainModel<MainForm>.NAME) as MainModel<MainForm>;
            if (model != null && model.IsValid())
            {
                model.Retrieve();
            }
        }
    }
}
