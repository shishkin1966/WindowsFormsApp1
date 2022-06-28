﻿using ClearArchitecture.SL;
using System;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1.App
{
    public class GetDocumentsRequest : BaseRequest
    {
        public const string NAME = "GetDocumentsRequest";
        private readonly ExtResult _result = new ExtResult().SetName(NAME);

        public GetDocumentsRequest(SqlConnection connection, string sender, string receiver, object obj) : base(connection, sender, receiver, obj)
        {
        }

        public override void Execute(object obj)
        {
            try
            {
                if (obj is IRequest requst)
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select top 50 * from Posts", Connection);
                    DataSet ds = new DataSet(NAME);
                    dataAdapter.Fill(ds, "Posts");
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

        public override void SendResult()
        {
            Program.SL.Messenger.AddNotMandatoryMessage(new ResultMessage(GetReceiver(), GetResult()));
        }
    }
}
