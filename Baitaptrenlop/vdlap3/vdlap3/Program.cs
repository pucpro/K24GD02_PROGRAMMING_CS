using System;
using System.Collections.Generic;

namespace vdlap3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HocSinh hs = new HocSinh();
            hs.NameChanged += Hs_NameChanged;

            hs.Name = "Tom";
            hs.Name = "Jerry";

            Console.ReadLine(); 
        }

        private static void Hs_NameChanged(object sender, changedNameEventArgs e)
        {
            Console.WriteLine("Hs_NameChanged: " + e.Name);
        }
    }

    class HocSinh
    {
        private string _name;
        private event EventHandler<changedNameEventArgs> _NameChanged;

        public event EventHandler<changedNameEventArgs> NameChanged
        {
            add => _NameChanged += value;
            remove => _NameChanged -= value;
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnNameChanged(value);
            }
        }

        void OnNameChanged(string name)
        {
            _NameChanged?.Invoke(this, new changedNameEventArgs(name)); 
        }
    }

    public class changedNameEventArgs : EventArgs
    {
        public readonly string Name;

        public changedNameEventArgs(string name)
        {
            Name = name;
        }
    }
}