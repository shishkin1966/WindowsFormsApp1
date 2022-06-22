using ClearArchitecture.SL;
using System;

namespace WindowsFormsApp1.App
{
    public class ApplicationProvider : AbsProvider, IApplicationProvider
    {
        public const string NAME = "ApplicationProvider";
        private bool _isExit = false;

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

        public bool IsExit()
        {
            return _isExit;
        }

        public void OnExit()
        {
            Console.WriteLine("Application exit");
        }

        public void SetExit()
        {
            _isExit = true;

            OnExit();
        }

    }
}
