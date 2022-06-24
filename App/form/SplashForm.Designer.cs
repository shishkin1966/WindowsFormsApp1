
using ClearArchitecture.SL;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    partial class SplashForm : IModelView<SplashForm>, IProgressBar
    {
        private IModel<SplashForm> _model;

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public IModel<SplashForm> GetModel()
        {
            return _model;
        }

        public bool IsValid()
        {
            if (GetState() != Lifecycle.ON_DESTROY && GetState() != Lifecycle.ON_CREATE) return true;
            return false;
        }

        public void SetModel(IModel<SplashForm> model)
        {
            base.RemoveLifecycleObserver(_model);
            _model = model;
            base.AddLifecycleObserver(_model);
        }

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashForm));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 427);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar1.Maximum = 5;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(448, 5);
            this.progressBar1.TabIndex = 0;
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(448, 432);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SplashForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        public void PerformStep()
        {
            ProgressBar.PerformStep();
        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;

        public ProgressBar ProgressBar
        {
            get
            {
                return progressBar1;
            }
        }
    }
}
