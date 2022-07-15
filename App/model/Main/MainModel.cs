using ClearArchitecture.SL;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public class MainModel<T> : BaseModel<T> where T : MainForm
    {
        public const string NAME = "MainModel";

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
            if (!IsValid()) return;

            if (this.GetView().InvokeRequired)
            {
                this.GetView().Invoke((MethodInvoker)(() =>
                {
                    UiRetrieve();
                }
                ));
            }
            else
            {
                UiRetrieve();
            }
        }

        private void UiRetrieve()
        {
            if (!IsValid()) return;

            List<string> list = Program.SL.Models.GetTitles();

            GetView().StatusStrip.Items.Clear();
            GetView().StatusStrip.LayoutStyle = ToolStripLayoutStyle.Flow;
            GetView().StatusStrip.Items.Add("Окна");

            foreach (string item in list)
            {
                var button = new Button();

                button.FlatStyle = FlatStyle.Popup;
                button.Text = item;
                button.Tag = item;
                button.Click += (sender, e) =>
                {
                    string title = (string)(sender as Button).Tag;
                    var model = Program.SL.Models.GetModelByTile(title);
                    if (model != null)
                    {
                        Program.SL.Messenger.AddNotMandatoryMessage(new SetFocusMessage(model.GetName()));
                    }
                };
                var control = new ToolStripControlHost(button);
                var margin = control.Margin;
                margin.Left = 1;
                margin.Right = 1;
                margin.Top = -2;
                control.Margin = margin;
                GetView().StatusStrip.Items.Add(control);
            }
        }
    }
}