using ClearArchitecture.SL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public partial class BaseForm : Form, ILifecycleObservable
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private readonly LifecycleObservable _lifecycleObservable = new LifecycleObservable(Lifecycle.ON_CREATE);

        public void AddLifecycleObserver(ILifecycle stateable)
        {
            if (stateable == null) return;

            _lifecycleObservable.AddLifecycleObserver(stateable);
        }

        public void ClearLifecycleObservers()
        {
            _lifecycleObservable.ClearLifecycleObservers();
        }

        public int GetState()
        {
            return _lifecycleObservable.GetState();
        }

        public void RemoveLifecycleObserver(ILifecycle stateable)
        {
            if (stateable == null) return;

            _lifecycleObservable.RemoveLifecycleObserver(stateable);
        }

        public void SetState(int state)
        {
            _lifecycleObservable.SetState(state);
        }

        public void Stop()
        {
            this.Dispose(true);
            this.Close();
        }

        virtual public string GetName()
        {
            return "BaseForm";
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            _lifecycleObservable.SetState(Lifecycle.ON_START);
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _lifecycleObservable.SetState(Lifecycle.ON_DESTROY);
        }

        private void BaseForm_Shown(object sender, EventArgs e)
        {
            _lifecycleObservable.SetState(Lifecycle.ON_READY);
        }

        public bool IsValid()
        {
            if (GetState() != Lifecycle.ON_DESTROY && GetState() != Lifecycle.ON_CREATE) return true;
            return false;
        }
    }
}
