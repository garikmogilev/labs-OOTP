using System;

namespace OOTP_Lab12
{
    public class User
    {
        public Action DelegateAction;            // public delegate void Action();
        public event Action EvenAction;               
        public Func<int, int> DelegateFunc;      // public delegate int DelegateFunc(int val);
        
        private int _version = 1;
        public string Name { get; }

        public User(string name)
        {
            this.Name = name;
        }

        public int Upgrade(int val)
        {
            _version = val;
            DelegateAction.Invoke();
            return _version;
        }

        public int CurrentVersion(int val)
        {
            Console.WriteLine($"Version: {val}");
            return val;
        }

        public readonly Action SystemMassage = () => Console.WriteLine("Version updated");
        

        public void Work()
        {
            Console.WriteLine("Work user!");
            EvenAction?.Invoke();
        }
        
    }
}