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

        /**
        * Ожидать без блокирования
        * @param milliseconds - задержка ожидания
        */
        void Wait(double milliseconds);

        /**
        * Ожидать с блокированием
        * @param milliseconds - задержка ожидания
        */
        void Sleep(int milliseconds);

        /**
        * Получить каталог программы
        * @return - каталог программы
        */
        string GetApplicationDir();

        /**
        * Получить полный путь приложения
        * @return - путь
        */
        string GetApplicationFullPath();

        /**
        * Получить имя приложения
        * @return - имя приложения
        */
        string GetApplicationName();

        /**
        * Получить имя файла приложения
        * @return - имя файла приложения
        */
        string GetApplicationFileName();
    }
}
