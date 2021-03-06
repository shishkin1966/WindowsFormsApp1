using ClearArchitecture.SL;
using WindowsFormsApp1.App;

namespace WindowsFormsApp1
{
    public class ProviderFactory : IProviderFactory, INamed
    {
        public const string NAME = "ProviderFactory";

        public IProvider Create(string name)
        {
            if (string.IsNullOrEmpty(name)) return default;

            try
            {
                switch (name)
                {
                    case ApplicationProvider.NAME:
                        return new ApplicationProvider(ApplicationProvider.NAME);
                    case LogProvider.NAME:
                        return new LogProvider(LogProvider.NAME);
                    case ExecutorUnion.NAME:
                        return new ExecutorUnion(ExecutorUnion.NAME);
                    case ObservableUnion.NAME:
                        return new ObservableUnion(ObservableUnion.NAME);
                    case MessengerUnion.NAME:
                        return new MessengerUnion(MessengerUnion.NAME);
                    case ModelUnion.NAME:
                        return new ModelUnion(ModelUnion.NAME);
                    case DbProvider.NAME:
                        return new DbProvider(DbProvider.NAME);
                    default:
                        return default;
                }
            }
            catch
            {
                return default;
            }
        }

        public string GetName()
        {
            return NAME;
        }
    }
}
