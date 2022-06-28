using ClearArchitecture.SL;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public partial class Forms : WindowsFormsApp1.App.BaseForm
    {
        private IModel<Forms> _model;

        public Forms()
        {
            SetModel(new FormsModel<Forms>(this));

            InitializeComponent();
        }

        public override string GetName()
        {
            return "Forms";
        }

        public IModel<Forms> GetModel()
        {
            return _model;
        }

        public void SetModel(IModel<Forms> model)
        {
            base.RemoveLifecycleObserver(_model);
            _model = model;
            base.AddLifecycleObserver(_model);
        }

        public bool IsValid()
        {
            if (GetState() != Lifecycle.ON_DESTROY && GetState() != Lifecycle.ON_CREATE) return true;
            return false;
        }

        private void listBox1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                var model = Program.SL.Models.GetModelByTile((string)ListBox.Items[index]);
                if (model != null)
                {
                    Program.SL.Messenger.AddNotMandatoryMessage(new SetFocusMessage(model.GetName()));
                    this.Close();
                }

            }
        }
    }
}
