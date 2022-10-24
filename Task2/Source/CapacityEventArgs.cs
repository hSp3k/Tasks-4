using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Source
{
    internal class CapacityEventArgs : EventArgs
    {
        public int OldCapacity { get; set; }
        public int NewCapacity { get; set; }

        public CapacityEventArgs(int oldCapacity, int newCapacity)
        {
            OldCapacity = oldCapacity;
            NewCapacity = newCapacity;
        }
    }
}
