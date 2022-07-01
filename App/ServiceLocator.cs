using ClearArchitecture.SL;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public class ServiceLocator : AbsServiceLocator, IServiceLocator
    {
        public const string NAME = "ServiceLocator";

        public ServiceLocator(string name) : base(name)
        {
        }

        public IApplicationProvider App
        {
            get
            {
                return (IApplicationProvider)GetProvider(ApplicationProvider.NAME);
            }
        }

        public IMessengerUnion Messenger
        {
            get
            {
                return (IMessengerUnion)GetProvider(MessengerUnion.NAME);
            }
        }

        public IObservableUnion Observable
        {
            get
            {
                return (IObservableUnion)GetProvider(ObservableUnion.NAME);
            }
        }

        public IExecutorUnion Executor
        {
            get
            {
                return (IExecutorUnion)GetProvider(ExecutorUnion.NAME);
            }
        }

        public ILogProvider Log
        {
            get
            {
                return (ILogProvider)GetProvider(LogProvider.NAME);
            }
        }

        public IModelUnion Models
        {
            get
            {
                return (IModelUnion)GetProvider(ModelUnion.NAME);
            }
        }
        public IDbProvider DB
        {
            get
            {
                return (IDbProvider)GetProvider(DbProvider.NAME);
            }
        }


        public override void Start()
        {
            Console.WriteLine(DateTime.Now.ToString("G") + ": " + "Старт SL");

            RegisterProvider(ApplicationProvider.NAME);
            RegisterProvider(LogProvider.NAME);
            RegisterProvider(MessengerUnion.NAME);
            RegisterProvider(ObservableUnion.NAME);
            RegisterProvider(ModelUnion.NAME);
            RegisterProvider(ExecutorUnion.NAME);
            RegisterProvider(DbProvider.NAME);
        }

        public override void Stop()
        {
            Console.WriteLine(DateTime.Now.ToString("G") + ": " + "Остановка Service Locator");

            base.Stop();

            Console.WriteLine(DateTime.Now.ToString("G") + ": " + "Выход из приложения");

            Application.Exit();
        }

        public override IProviderFactory GetProviderFactory()
        {
            return new ProviderFactory();
        }

        public override bool RegisterSubscriber(IProviderSubscriber subscriber)
        {
            if (subscriber == null) return true;

            if (!base.RegisterSubscriber(subscriber)) return false;
            if (subscriber is IObservableSubscriber)
            {
                return Observable.RegisterSubscriber(subscriber);
            }
            return true;
        }

        public override void UnRegisterSubscriber(IProviderSubscriber subscriber)
        {
            if (subscriber == null) return;

            base.UnRegisterSubscriber(subscriber);
            if (subscriber is IObservableSubscriber)
            {
                Observable.UnRegisterSubscriber(subscriber);
            }
        }

    }
}
