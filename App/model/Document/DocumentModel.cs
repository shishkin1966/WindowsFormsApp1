using ClearArchitecture.SL;
using System.Data;

namespace WindowsFormsApp1.App
{
    public class DocumentModel<T> : ResponseModel<T> where T : DocumentForm
    {
        public const string NAME = "DocumentModel";

        public DocumentModel(DocumentForm form) : base(NAME, (IModelView<T>)form)
        {
        }

        public override string GetTitle()
        {
            return GetView().Text;
        }

        public override void OnStart()
        {
            base.OnStart();

            GetView().ShowProgressBar();
            var connection = Program.SL.DB.GetDb(new DbConficuration(ApplicationProvider.DBNAME));
            GetView().HideProgressBar();

            GetView().ShowProgressBar();
            GetView().SetStatus("Загрузка ...");
            Program.SL.Executor.PutRequest(new GetDocumentsRequest(connection, GetName(), GetName(), 0));
        }

        public override void OnUpdateUI(ExtResult result)
        {
            if (!IsValid()) return;

            GetView().HideProgressBar();
            if (result.HasError())
            {
                OnError(result.GetError());
            }
            else
            {
                if (result.GetName() == GetDocumentsRequest.NAME)
                {
                    DataSet ds = (DataSet)result.GetData();
                    GetView().DataGridView.ReadOnly = true;
                    GetView().DataGridView.AllowUserToAddRows = false;
                    GetView().DataGridView.DataSource = ds.Tables["Posts"];
                    GetView().SetStatus("Всего: " + GetView().DataGridView.RowCount.ToString() + " строк(а)");
                }
            }
        }
    }
}