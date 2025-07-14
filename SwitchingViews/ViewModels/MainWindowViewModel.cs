using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SwitchingViews.ViewModels.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchingViews.ViewModels
{

    partial class MainWindowViewModel: BaseViewModel
    {
        [ObservableProperty]
        private MainWindowViewModel viewModel;

        [ObservableProperty]
        private BaseViewModel selectedViewModel;
        
        [ObservableProperty]
        private string? title = "Daniel";


        public MainWindowViewModel(MainWindowViewModel viewModel) 
        {
            this.viewModel = viewModel;
        }

        [RelayCommand]
        private void Home()
        {
            viewModel.selectedViewModel = new HomeViewModel();
            Debug.WriteLine("Home is on");
        }

        [RelayCommand]
        private void Account() 
        {
            viewModel.selectedViewModel = new AccountViewModel();
            Debug.WriteLine("Account is on");
        }
    }
}
