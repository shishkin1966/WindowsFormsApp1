using ClearArchitecture.SL;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public abstract class ResponseModel<T> : BaseModel<T>, IResponseListener, IObservableSubscriber where T : Control
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

        public List<string> GetObservable()
        {
            List<string> list = new List<string>();
            list.Add(FormsModelObservable.NAME);
            return list;
        }

        public void OnChangeObservable(string observable, object obj)
        {
            //
        }

        public void OnStopObservable(string observable)
        {
            //
        }
    }
}
