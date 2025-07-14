using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchingViews.ViewModels
{
    partial class HomeViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string? text = "David";

        [RelayCommand]
        private void MouseEnter()
        {
            Text = "Mouse over";
        }
        public HomeViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                this.text = "Jiri";
            }
        }
    }
}
