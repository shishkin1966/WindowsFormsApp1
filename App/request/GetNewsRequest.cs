using ClearArchitecture.SL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1.App
{
    public class GetNewsRequest : BaseRequest
    {
        public const string NAME = "GetNewsRequest";
        private readonly ExtResult _result = new ExtResult().SetName(NAME);

        public GetNewsRequest(SqlConnection connection, string sender, string receiver, object obj) : base(connection, sender, receiver, obj)
        {
        }

        public override void Execute(object obj)
        {
            try
            {
                if (obj is IRequest requst)
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select top 100 * from Comments", Connection);
                    DataSet ds = new DataSet(NAME);
                    dataAdapter.Fill(ds, "Comments");
                    _result.SetData(ds);
                    SetResult(_result);
                }
            }
            catch (Exception e)
            {
                Program.SL.Log.AddError(new ExtError().AddError(GetName(), e));
                SetResult(_result.SetError(new ExtError(GetName(), e)));
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
    }
}
