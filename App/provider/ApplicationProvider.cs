using ClearArchitecture.SL;
using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1.App
{
    public class ApplicationProvider : AbsProvider, IApplicationProvider
    {
        public const string NAME = "ApplicationProvider";
        public const string DBNAME = "DB";

        public ApplicationProvider(string name) : base(name)
        {
        }

        public override int CompareTo(IProvider other)
        {
            if (other is IApplicationProvider)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public string GetApplicationName()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        }

        public string GetApplicationFullPath()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location;
        }

        public string GetApplicationDir()
        {
            return System.AppContext.BaseDirectory;
        }

        public string GetApplicationFileName()
        {
            return System.AppDomain.CurrentDomain.FriendlyName;
        }

        public void Sleep(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public void Wait(double milliseconds)
        {
            DateTime next = System.DateTime.Now.AddMilliseconds(milliseconds);
            while (next > System.DateTime.Now)
                Application.DoEvents();
        }
    }
}