using ClearArchitecture.SL;

namespace WindowsFormsApp1.App
{
    public class SplashModel<T> : BaseModel<T> where T: SplashForm
    {
        public const string NAME = "SplashModel";

        public SplashModel(SplashForm form) : base(NAME, (IModelView<T>)form)
        {
        }
    }
}
