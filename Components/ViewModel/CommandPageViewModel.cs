using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Components.Model;
using System.Diagnostics;
using Components.ViewModel;
using CommunityToolkit.Mvvm.Messaging;
using Components.Model;
using Components.ViewModel.Messages;

namespace Components.ViewModel
{
    partial class CommandPageViewModel: BaseViewModel
    {
        ComponentType model;
        public CommandPageViewModel() 
        {
           
            WeakReferenceMessenger.Default.Register<CommandChangedMessage>(this, (r, m)) =>
                { }
        }

        [RelayCommand]
        private void ZeroD()
        {
            model.Type = ComponentTypeEnum.ZeroDComponent;
  //          mainWindowViewModel.ComponentType = ComponentTypeEnum.ZeroDComponent;
  //          Debug.WriteLine(mainWindowViewModel.ComponentType);
  //          mainWindowViewModel.ComponentTypeText = "0D";
  //          mainWindowViewModel.SelectedViewModel = new ZeroDComponentViewModel();
        }

        [RelayCommand]
        private void OneD() 
        {          

        }

        [RelayCommand]
        private void ThreeD() 
        {

        }
    }
}
