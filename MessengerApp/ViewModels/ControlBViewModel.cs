using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;

namespace MessengerApp.ViewModels
{
    public partial class ControlBViewModel: ObservableRecipient
    {
        [ObservableProperty]
        public string contentA = "No content";

        public ControlBViewModel()
        {
            WeakReferenceMessenger.Default.Register<ContentChanged>(this, 
                (r, m) => 
                {
                    ContentA = m.Name;
                });


        }
    }
}
