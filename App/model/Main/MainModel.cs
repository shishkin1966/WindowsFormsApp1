using ClearArchitecture.SL;

namespace WindowsFormsApp1.App
{
    public class MainModel<MainForm> : AbsModel<MainForm>
    {
        public const string NAME = "MainModel";

        public MainModel(MainForm form) : base(NAME, (IModelView<MainForm>)form)
        {
        }

        public override void OnStart()
        {
            Program.SL.RegisterSubscriber(this);
        }

        public override void Read(IMessage message)
        {
            //
        }
    }
}
