using ClearArchitecture.SL;
using System.Threading;

namespace WindowsFormsApp1.App
{
    public class SplashModel<T> : AbsModel<T> where T: SplashForm
    {
        public const string NAME = "SplashModel";

        public SplashModel(SplashForm form) : base(NAME, (IModelView<T>)form)
        {
        }

        public override void Read(IMessage message)
        {
        }

        public override void OnStart()
        {
            Program.SL.RegisterSubscriber(this);
        }
    }
}
