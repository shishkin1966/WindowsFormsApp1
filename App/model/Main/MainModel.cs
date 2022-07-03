using ClearArchitecture.SL;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public class MainModel<T> : BaseModel<T> where T: MainForm
    {
        public const string NAME = "MainModel";
        private readonly FormsModelObservable _observable = new FormsModelObservable();

        public FormsModelObservable FormsModelObservable
        {
            get
            {
                return _observable;
            }
        }

        public MainModel(MainForm form) : base(NAME, (IModelView<T>)form)
        {
        }

        public override string GetTitle()
        {
            return "";
        }

        public override void OnStart()
        {
            base.OnStart();

            Retrieve();

            Program.SL.Observable.RegisterObservable(FormsModelObservable);

            var form = new SplashForm();
            form.ShowDialog();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            Program.SL.Stop();
        }

        public void Retrieve()
        {
            List<string> list = Program.SL.Models.GetTitles();

            GetView().StatusStrip.Items.Clear();
            foreach (string item in list)
            {
                var button = new Button();
                button.FlatStyle = FlatStyle.Flat;
                button.Size = new Size(60, 10);
                button.Text = item;
                button.Click += (sender, e) =>
                {
                    string title = (sender as Button).Text;
                    var model = Program.SL.Models.GetModelByTile(title);
                    if (model != null)
                    {
                        Program.SL.Messenger.AddNotMandatoryMessage(new SetFocusMessage(model.GetName()));
                    }
                };
                GetView().StatusStrip.Items.Add(new ToolStripControlHost(button));
            }
        }
    }
}
