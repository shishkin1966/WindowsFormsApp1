using ClearArchitecture.SL;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public class MainModel<MainForm> : AbsModel<MainForm>
    {
        public MainModel(MainForm form) : base((IModelView<MainForm>)form)
        {
        }

        public override void OnReady()
        {
            MessageBox.Show("MainForm OnReady","Внимание");
        }

    }
}
