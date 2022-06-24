using ClearArchitecture.SL;
using System;
using System.Threading;

namespace WindowsFormsApp1.App
{
    public class ShowSplashFormRequest : AbsRequest, IRequest
    {
        public const string NAME = "ShowSplashFormRequest";

        private SplashForm form;

        public ShowSplashFormRequest(string sender, string receiver, object obj) : base(sender, receiver, obj)
        {
        }

        public override void Execute(object obj)
        {
            try
            {
                form = new SplashForm();
                form.Show();

                if (obj is IRequest requst)
                {
                    Thread.Sleep(1000);
                    SetResult(new ExtResult(requst.GetData()));
                }
            }
            catch (Exception e)
            {
                Program.SL.Log.AddError(new ExtError().AddError(GetName(), e));
            }
            finally
            {
                SendResult();
                RemoveRequest();
            }
        }

        public override string GetName()
        {
            return NAME;
        }

        public override void SendResult()
        {
            if (form != null)
            {
                form.Close();
            }
        }
    }
}
