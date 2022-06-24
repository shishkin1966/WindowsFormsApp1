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

        void Wait(double milliseconds);

        void Sleep(int milliseconds);

        string GetApplicationDir();

        string GetApplicationFullPath();

        string GetApplicationName();

        string GetApplicationFileName();
    }
}
