using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ViewModels
{
    public partial class ControlAViewModel: ObservableObject
    {
        [RelayCommand]
        private void ButtonClick(object parameter) 
        {
            WeakReferenceMessenger.Default.Send(new ContentChanged(parameter.ToString()));
            Debug.WriteLine(parameter);
        }
    }
}
