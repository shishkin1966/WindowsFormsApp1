using ClearArchitecture.SL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public partial class BaseForm : Form, IFormSubscriber
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private bool _isBusy = false;
        private readonly StringBuilder _comment = new StringBuilder();
        private readonly Secretary<string> _providers = new Secretary<string>();
        private readonly LifecycleObservable _lifecycleObservable = new LifecycleObservable(Lifecycle.VIEW_CREATE);
        private readonly List<IAction> _actions = new List<IAction>();

        public void AddAction(IAction action)
        {
            if (action == null) return;

            switch (GetState())
            {
                case Lifecycle.VIEW_READY:
                    if (!action.IsRun())
                    {
                        _actions.Add(action);
                    }
                    DoActions();
                    break;
                case Lifecycle.VIEW_CREATE:
                case Lifecycle.VIEW_NOT_READY:
                    if (!action.IsRun())
                    {
                        _actions.Add(action);
                    }
                    break;
            }
        }

        private void DoActions()
        {
            var deleted = new List<IAction>();
            for (int i = 0; i < _actions.Count; i++)
            {
                if (GetState() != Lifecycle.VIEW_READY)
                {
                    break;
                }
                if (!_actions[i].IsRun())
                {
                    _actions[i].SetRun();
                    OnAction(_actions[i]);
                    deleted.Add(_actions[i]);
                }
            }
            foreach (IAction action in deleted)
            {
                _actions.Remove(action);
            }
        }

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

        public bool IsValid()
        {
            return true;
        }

        public bool OnAction(IAction action)
        {
            return true;
        }

        public void RemoveLifecycleObserver(ILifecycle stateable)
        {
            if (stateable == null) return;

            _lifecycleObservable.RemoveLifecycleObserver(stateable);
        }

        public void SetState(int state)
        {
            //
        }

        public void Stop()
        {
            _providers.Clear();

            this.Dispose(true);
            this.Close();
        }

        virtual public string GetName()
        {
            return "BaseForm";
        }

        public bool IsBusy()
        {
            return _isBusy;
        }

        public void SetBusy()
        {
            _isBusy = true;
        }

        public void SetUnBusy()
        {
            _isBusy = false;
        }

        public void AddComment(string comment)
        {
            _comment.Append(DateTime.Now.ToString("G") + ": " + comment);
        }

        public string GetComment()
        {
            return _comment.ToString();
        }

        public void OnStopProvider(string provider)
        {
            if (string.IsNullOrEmpty(provider)) return;

            RemoveProvider(provider);
            OnRemoveProvider(provider);
        }

        public List<string> GetProviders()
        {
            return _providers.Values();
        }
        public void SetProvider(string provider)
        {
            if (string.IsNullOrEmpty(provider)) return;

            _providers.Put(provider, provider);
            OnSetProvider(provider);
        }

        public void RemoveProvider(string provider)
        {
            if (string.IsNullOrEmpty(provider)) return;

            _providers.Remove(provider);
        }

        public void OnSetProvider(string provider)
        {
            Console.WriteLine(DateTime.Now.ToString("G") + ": Подключен к провайдеру " + provider + " подписчик " + GetName());
        }

        public void OnRemoveProvider(string provider)
        {
            Console.WriteLine(DateTime.Now.ToString("G") + ": Отключен от провайдера " + provider + " подписчик " + GetName());
        }

        public List<string> GetProviderSubscription()
        {
            List<string> list = new List<string>
            {
                FormUnion.NAME
            };
            return list;
        }

    }
}
