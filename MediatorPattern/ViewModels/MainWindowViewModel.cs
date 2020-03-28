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
            TBoxFN = new TBox(Mediator);
            TBoxLN = new TBox(Mediator);
            TBoxEmail = new TBox(Mediator);
            TBoxAge = new TBox(Mediator);
            RegisterBtn = new Btn(Mediator);
        }

    }
    public class TBox : IObserver
    {
        private string text;

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);

        }

        public TBox(Mediator m) : base(m)
        {
        }

        public override bool IsValid()
        {
            if (string.IsNullOrEmpty(Text))
                return false;
            else
                return true;
        }

        private ICommand _notifyMediator;

        public ICommand NotifyMediator => _notifyMediator ?? (_notifyMediator = new DelegateCommand(Update));
    }

    public class Btn : IObserver
    {
        private bool state;

        public bool BtnIsEnabled
        {
            get => state;
            set => SetProperty(ref state, value);
        }

        public Btn(Mediator m) : base(m)
        {
            BtnIsEnabled = false;
        }

        public override void ChangeBtnState(bool state)
        {
            BtnIsEnabled = state;
        }
    }
}
