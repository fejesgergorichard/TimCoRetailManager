using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using TRMDesktopUI.EventModels;
using TRMDesktopUI.Library.Models;

namespace TRMDesktopUI.ViewModels
{
                                         // First step of event handling is implementing the IHandle for the specific event message object so the
                                         // ShellViewModel is listening to that type of event and gets notified when it fires
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private SalesViewModel salesVM;
        SimpleContainer container;
        private IEventAggregator events;

        public ShellViewModel(SimpleContainer _container, SalesViewModel _salesVM,
            IEventAggregator _events)
        {
            container = _container;
            salesVM = _salesVM;

            events = _events;

            // Second step of event handling
            // We subscribe with the current instance of the shell view model
            events.Subscribe(this);

            // Get a new instance of LoginViewModel and activate it (its PerRequest)
            // this way we never have data from the previous state
            base.ActivateItem(container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            base.ActivateItem(salesVM);
        }

        public void LoginScreen()
        {
            base.ActivateItem(container.GetInstance<LoginViewModel>());
        }
    }
}
