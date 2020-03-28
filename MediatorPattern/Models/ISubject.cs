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
    public abstract class ISubject
    {
        public abstract void Notify(MessageType m);

        protected List<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver ob) => observers.Add(ob);

        public void Detach(IObserver ob) => observers.Remove(ob);
    }

    public abstract class IObserver : BindableBase
    {

        protected Mediator Mediator;

        protected IObserver(Mediator m)
        {
            Mediator = m;
            Mediator.Attach(this);
        }

        public virtual void Update()
        {
            Mediator.Notify(MessageType.Input);
        }

        public virtual bool IsValid() => true;

        public virtual void MakeBtnActive() {}

    }
}
