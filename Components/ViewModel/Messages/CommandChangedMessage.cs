using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Components.Model;

namespace Components.ViewModel.Messages
{
    internal class CommandChangedMessage(ComponentType value): ValueChangedMessage<ComponentType>(value);
}
