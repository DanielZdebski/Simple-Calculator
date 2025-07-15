using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SwitchingViews.ViewModels.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchingViews.ViewModels
{
    partial class MainWindowViewModel: BaseViewModel
    {
        [ObservableProperty]
        private BaseViewModel selectedViewModel = new HomeViewModel();
        
        [ObservableProperty]
        private string? title = "Daniel";



        [RelayCommand]
        private void Home()
        {
            selectedViewModel = new HomeViewModel();
        }

        [RelayCommand]
        private void Account() 
        {
            selectedViewModel = new AccountViewModel();
        }
    }
}
