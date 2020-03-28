using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace MediatorPattern.Models
{
    public abstract class Observer : BindableBase
    {

        protected Mediator Mediator;

        protected Observer(Mediator m)
        {
            Mediator = m;
            Mediator.Attach(this);
        }

        public abstract void Update(bool state);

        public virtual bool IsValid() => true; //Hook-Method for validation-check.
    }
}
