using ClearArchitecture.SL;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public abstract class BaseModel<T> : AbsModel<T>
    {
        protected BaseModel(string name, IModelView<T> form) : base(name, form)
        {
        }

        public override void OnStart()
        {
            Program.SL.RegisterSubscriber(this);
        }

        public override void Read(IMessage message)
        {
            if (message.GetName() == SetFocusMessage.NAME)
            {
                if (GetView() is Control)
                {
                    (GetView() as Control).Focus();
                }
            }
        }

        public override void OnDestroy()
        {
            Program.SL.UnRegisterSubscriber(this);
        }
    }
}