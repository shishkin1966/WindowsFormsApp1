using ClearArchitecture.SL;
using System;

namespace WindowsFormsApp1.App
{
    public class StepSplashFormRequest : AbsRequest
    {
        public const string NAME = "StepSplashFormRequest";

        public StepSplashFormRequest(string sender, string receiver, object obj) : base(sender, receiver, obj)
        {
        }

        public override void Execute(object obj)
        {
            try
            {
                if (obj is IRequest requst)
                {
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
        }
    }
}
