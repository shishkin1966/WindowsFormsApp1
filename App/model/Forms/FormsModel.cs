using ClearArchitecture.SL;
using System.Collections.Generic;

namespace WindowsFormsApp1.App
{
    public class FormsModel<T> : BaseModel<T> where T : Forms
    {
        public const string NAME = "FormsModel";

        public FormsModel(Forms form) : base(NAME, (IModelView<T>)form)
        {
        }

        public override string GetTitle()
        {
            return "";
        }

        public override void OnStart()
        {
            base.OnStart();

            List<string> list = Program.SL.Models.GetTitles();
            foreach(string item in list)
            {
                GetView().ListBox.Items.Add(item);
            }
        }
    }
}
