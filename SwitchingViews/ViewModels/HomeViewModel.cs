using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchingViews.ViewModels
{
    partial class HomeViewModel: BaseViewModel
    {
        [ObservableProperty]
        private string? text = "Jiri";

    }
}
