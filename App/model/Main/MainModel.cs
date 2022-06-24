using ClearArchitecture.SL;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public class MainModel<T> : AbsModel<T> where T: MainForm
    {
        public const string NAME = "MainModel";

        public MainModel(MainForm form) : base(NAME, (IModelView<T>)form)
        {
        }

        public override void OnStart()
        {
            Program.SL.RegisterSubscriber(this);

            Program.SL.Executor.PutRequest(new ShowSplashFormRequest(GetName(), "", ""));
        }

        public override void Read(IMessage message)
        {
        }
    }
}
