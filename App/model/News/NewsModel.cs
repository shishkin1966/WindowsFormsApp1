using ClearArchitecture.SL;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public class NewsModel<T> : ResponseModel<T> where T : NewsForm
    {
        public const string NAME = "NewsModel";

        public NewsModel(NewsForm form) : base(NAME, (IModelView<T>)form)
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
            Program.SL.Executor.PutRequest(new GetNewsRequest(connection, GetName(), GetName(), 0));
        }

        public override void OnUpdateUI(ExtResult result)
        {
            if (!IsValid()) return;

            GetView().HideProgressBar();
            if (result.HasError())
            {
                MessageBox.Show("Ошибка", result.GetErrorText());
            }
            else
            {
                if (result.GetName() == GetNewsRequest.NAME)
                {
                    DataSet ds = (DataSet)result.GetData();
                    GetView().DataGridView.ReadOnly = true;
                    GetView().DataGridView.AllowUserToAddRows = false;
                    GetView().DataGridView.DataSource = ds.Tables["Comments"];
                    GetView().SetStatus("Всего: " + GetView().DataGridView.RowCount.ToString() + " строк(а)");
                }
            }
        }
    }
}