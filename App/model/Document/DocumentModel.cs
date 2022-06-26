using ClearArchitecture.SL;

namespace WindowsFormsApp1.App
{
    public class DocumentModel<T> : BaseModel<T> where T : DocumentForm
    {
        public const string NAME = "DocumentModel";

        public DocumentModel(DocumentForm form) : base(NAME, (IModelView<T>)form)
        {
        }

        public override void OnStart()
        {
            base.OnStart();

            GetView().ShowProgressBar();
            //CompuMaster.Data.DataQuery.AnyIDataProvider.FillDataTable();
        }
    }
}
