
using ClearArchitecture.SL;
using System.Data.SqlClient;

namespace WindowsFormsApp1.App
{
    public abstract class BaseRequest : AbsRequest
    {
        private readonly SqlConnection _connection;

        public SqlConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        protected BaseRequest(SqlConnection connection, string sender, string receiver, object obj) : base(sender, receiver, obj)
        {
            _connection = connection;
        }

        public override void SendResult()
        {
            Program.SL.Messenger.AddNotMandatoryMessage(new ResultMessage(GetReceiver(), GetResult()));
        }
    }
}
