using ClearArchitecture.SL;
using System.Data.SqlClient;

namespace WindowsFormsApp1.App
{
    public class DocumentModel<T> : BaseModel<T> where T : DocumentForm
    {
        public const string NAME = "DocumentModel";
        private SqlConnection _connection;

        public DocumentModel(DocumentForm form) : base(NAME, (IModelView<T>)form)
        {
        }

        public override void OnStart()
        {
            base.OnStart();

            GetView().ShowProgressBar();
            _connection = Program.SL.DB.GetDb(new DbConficuration(NAME));
            GetView().HideProgressBar();
        }

        public override void OnDestroy()
        {
            Program.SL.DB.Disconnect(NAME);
        }
    }
}
