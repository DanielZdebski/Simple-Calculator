using CommunityToolkit.Mvvm.ComponentModel;
using Components.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.ViewModel
{
    [ObservableObject]
    public partial class MainWindowViewModel : BaseViewModel
    {
        [ObservableProperty]
        public BaseViewModel selectedViewModel = new ZeroDComponentViewModel();

        [ObservableProperty]
        public ComponentTypeEnum componentType;

        [ObservableProperty]
        public string componentTypeText = "Daniel";

    }
}
