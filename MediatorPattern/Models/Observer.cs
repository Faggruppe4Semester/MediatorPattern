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

        //Hook-Methods for optional update in internal object, or extra validation.
        public virtual void Update(bool state) { }

        public virtual bool IsValid() => true;
    }
}
