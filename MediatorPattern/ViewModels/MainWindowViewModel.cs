using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MediatorPattern.Models;
using Prism.Commands;
using Prism.Mvvm;

namespace MediatorPattern.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public Mediator Mediator { get; set; }
        public TBox TBoxFN { get; set; }
        public TBox TBoxLN { get; set; }
        public TBox TBoxEmail { get; set; }
        public TBox TBoxAge { get; set; }
        public Btn RegisterBtn { get; set; }

        public MainWindowViewModel()
        {
            Mediator = new Mediator();
            TBoxFN = new TBox(Mediator, MessageType.Input);
            TBoxLN = new TBox(Mediator, MessageType.Input);
            TBoxEmail = new TBox(Mediator, MessageType.Input);
            TBoxAge = new TBox(Mediator, MessageType.Input);
            RegisterBtn = new Btn(Mediator);
        }

    }
    public class TBox : Observer
    {
        public MessageType MessageType { get; set; }
        private string text;

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);

        }

        public TBox(Mediator m, MessageType msgType) : base(m)
        {
            MessageType = msgType;
        }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Text))
                return false;
            else
                return true;
        }

        private ICommand _notifyMediator;

        public ICommand NotifyMediator => _notifyMediator ?? (_notifyMediator = new DelegateCommand<object>(Mediator.Notify));
    }

    public class Btn : Observer
    {
        private bool _btnIsEnabled;

        public bool BtnIsEnabled
        {
            get => _btnIsEnabled;
            set => SetProperty(ref _btnIsEnabled, value);
        }

        public Btn(Mediator m) : base(m)
        {
            BtnIsEnabled = false;
        }

        public override void Update(bool state)
        {
            BtnIsEnabled = state;
        }
    }
}
