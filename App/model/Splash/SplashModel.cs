using ClearArchitecture.SL;

namespace WindowsFormsApp1.App
{
    public class SplashModel<T> : BaseModel<T> where T : SplashForm
    {
        public const string NAME = "SplashModel";

        public SplashModel(SplashForm form) : base(NAME, (IModelView<T>)form)
        {
        }

        public override string GetTitle()
        {
            return GetView().Text;
        }

        public override void OnReady()
        {
            base.OnReady();

            for (int i = 1; i < 6; i++)
            {
                Program.SL.App.Wait(300);
                GetView().StepProgressBar();
            }
            GetView().Close();
        }
    }
}
