using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MediatorPattern.Models
{
    public enum MessageType
    {
        Register, Clear, Input
    }

    public class Mediator : ISubject
    {
        public override void Notify(MessageType m)
        {
            if (m == MessageType.Input)
            {
                bool allIsValid = true;
                foreach (var observer in observers)
                {
                    if (!observer.IsValid())
                        allIsValid = false;
                }

                if (allIsValid)
                {
                    foreach (var observer in observers)
                    {
                        observer.MakeBtnActive();
                    }
                }
            }
        }
    }
}
