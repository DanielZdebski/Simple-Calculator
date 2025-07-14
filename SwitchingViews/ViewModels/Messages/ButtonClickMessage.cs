using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchingViews.ViewModels.Messages
{
    class ButtonClickMessage: ValueChangedMessage<MainWindowViewModel>
    {
        public ButtonClickMessage(MainWindowViewModel value) : base(value)
        {
        }
    }
}
