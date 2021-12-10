using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment.Interfaces
{
    public interface IObservable<T> where T:class
    {
        public void Attach(IObserver<T> observer);
        public void Notify();
    }
}
