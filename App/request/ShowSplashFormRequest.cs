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
                    form.ProgressBar.Step = 1;
                    form.ProgressBar.Maximum = 5;
                    form.ProgressBar.Value = 0;

                    form.ProgressBar.ResumeLayout(false);
                    for (int i = 1; i < 6; i++)
                    {
                        Thread.Sleep(300);
                        //Thread.Yield();
                        form.ProgressBar.PerformStep();
                    }

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
