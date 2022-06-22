using ClearArchitecture.SL;

namespace WindowsFormsApp1.App
{
    public interface IApplicationProvider : IProvider
    {
        /**
        * Флаг - выход из приложения
        *
        * @return true = приложение остановлено
        */
        bool IsExit();
        
        void SetExit();

        void OnExit();
    }
}
