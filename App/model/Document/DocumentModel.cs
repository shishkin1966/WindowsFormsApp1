using ClearArchitecture.SL;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public class DocumentModel<T> : ResponseModel<T> where T : DocumentForm
    {
        public const string NAME = "DocumentModel";

        public DocumentModel(DocumentForm form) : base(NAME, (IModelView<T>)form)
        {
        }

        public override void OnStart()
        {
            base.OnStart();

            GetView().ShowProgressBar();
            var connection = Program.SL.DB.GetDb(new DbConficuration(ApplicationProvider.DBNAME));
            GetView().HideProgressBar();

            GetView().ShowProgressBar();
            Program.SL.Executor.PutRequest(new GetDocumentsRequest(connection, NAME, NAME, 0));
        }

        public override void OnUpdateUI(ExtResult result)
        {
            GetView().HideProgressBar();
            if (result.HasError())
            {
                MessageBox.Show("Ошибка", result.GetErrorText());
            }
            else
            {
                DataSet ds = (DataSet)result.GetData();
                GetView().DataGridView.DataSource = ds.Tables["Posts"];
            }
        }
    }
}
