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
        private BaseViewModel? selectedViewModel;
        
        [ObservableProperty]
        private string title = "Daniel";

        [RelayCommand]
        private void Home()
        {
            SelectedViewModel = new HomeViewModel();
            Title = "Home";
            Debug.WriteLine("Home is on");
        }

        [RelayCommand]
        private void Account() 
        {
            Title = "Account";
            SelectedViewModel = new AccountViewModel();
            Debug.WriteLine("Account is on");
        }

        public MainWindowViewModel() 
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                selectedViewModel= new HomeViewModel();
            }
        }
    }
}
