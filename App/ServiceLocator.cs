using ClearArchitecture.SL;
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

        public IExecutorProvider Executor
        {
            get
            {
                return (IExecutorProvider)GetProvider(ExecutorProvider.NAME);
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


        public override void Start()
        {
            RegisterProvider(ApplicationProvider.NAME);
            RegisterProvider(LogProvider.NAME);
            RegisterProvider(MessengerUnion.NAME);
            RegisterProvider(ObservableUnion.NAME);
            RegisterProvider(ModelUnion.NAME);
            RegisterProvider(ExecutorProvider.NAME);
        }

        public override void Stop()
        {
            App.SetExit();

            base.Stop();

            Application.Exit();
        }

        public override IProviderFactory GetProviderFactory()
        {
            return new ProviderFactory();
        }
    }
}
