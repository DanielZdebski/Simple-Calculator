using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Input;

namespace _06_CommunityToolkit_example.ViewModel
{
    public record class userLoggedIn(string UserName);

    [ObservableObject]
    public partial class MainWindowViewModel
    {
        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ClickCommand))]
        private string? firstName = "Daniel";

        public MainWindowViewModel()
        {
        }

        [RelayCommand(IncludeCancelCommand = true)]
        private async Task Click(CancellationToken token)
        {
            try { 
                await Task.Delay(5_000, token);
                FirstName += " Robert";
            }
            catch(OperationCanceledException)
            {
                FirstName += " x";
            }
        }

        private bool CanClick() => FirstName == "Daniel";

        public void Receive(userLoggedIn message)
        {
            
        }
    }

}
