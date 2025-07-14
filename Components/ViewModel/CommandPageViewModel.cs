using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components.Model;
using System.Diagnostics;

namespace Components.ViewModel
{
    partial class CommandPageViewModel: MainWindowViewModel
    {

        [RelayCommand]
        private void ZeroD()
        {
            componentType = ComponentTypeEnum.ZeroDComponent;
            Debug.WriteLine(componentType);
            componentTypeText = "0D";
            selectedViewModel = new ZeroDComponentViewModel();
        }

        [RelayCommand]
        private void OneD() 
        {
            componentType = ComponentTypeEnum.OneDComponent;
            componentTypeText = "1D";
            Debug.WriteLine(componentType);
            selectedViewModel = new OneDComponentViewModel();
        }

        [RelayCommand]
        private void ThreeD() 
        {
            
            componentType = ComponentTypeEnum.ThreeDComponent;
            componentTypeText = "3D";
            Debug.WriteLine(componentType);
            selectedViewModel = new ThreeDComponentViewModel();
        }
    }
}
