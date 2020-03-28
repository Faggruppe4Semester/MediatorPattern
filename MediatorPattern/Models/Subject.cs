using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;
using Prism.Mvvm;

namespace MediatorPattern.Models
{
    public abstract class Subject
    {
        public abstract void Notify(object m);

        protected List<Observer> observers = new List<Observer>();

        public void Attach(Observer ob) => observers.Add(ob);

        public void Detach(Observer ob) => observers.Remove(ob);
    }
}
