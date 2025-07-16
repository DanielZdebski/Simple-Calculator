using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MessengerApp.ViewModels
{
    public partial class MainWindowViewModel:ObservableObject
    {
        [ObservableProperty]
        ControlAViewModel controlAViewModel = new ControlAViewModel();

        [ObservableProperty]
        ControlBViewModel controlBViewModel = new ControlBViewModel();

    }
}
