using ClearArchitecture.SL;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public abstract class ResponseModel<T> : BaseModel<T>, IResponseListener  where T : Control
    {
        protected ResponseModel(string name, IModelView<T> form) : base(name, form)
        {
        }

        public void Response(ExtResult result)
        {
            if (this.GetView().InvokeRequired)
            {
                this.GetView().Invoke((MethodInvoker)(() =>
                {
                    OnUpdateUI(result);
                }
                ));
            }
            else
            {
                OnUpdateUI(result);
            }
        }

        public abstract void OnUpdateUI(ExtResult result);

        public override void OnDestroy()
        {
            base.OnDestroy();

            Program.SL.Executor.CancelRequests(GetName());
        }
    }
}
