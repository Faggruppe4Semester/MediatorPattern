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

    public class Mediator : Subject
    {
        public override void Notify(object m)
        {
            var msgType = m as MessageType?;
            switch (msgType)
            {
                case null:
                    throw new ArgumentNullException("The MessageType had a value of NULL.");

                case MessageType.Register:
                    break;

                case MessageType.Clear:
                    break;

                case MessageType.Input:
                {
                    var allIsValid = true;
                    foreach (var observer in observers)
                    {
                        if (!observer.IsValid())
                            allIsValid = false;
                    }

                    if (allIsValid)
                    {
                        foreach (var observer in observers)
                        {
                            observer.Update(true);
                        }
                    }
                    else
                    {
                        foreach (var observer in observers)
                        {
                            observer.Update(false);
                        }
                    }
                    break;
                }
            }
        }
    }
}
