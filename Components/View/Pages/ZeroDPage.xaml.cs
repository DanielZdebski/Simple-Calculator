using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Components.ViewModel;

namespace Components.View.Pages
{
    /// <summary>
    /// Interaction logic for ZeroDPage.xaml
    /// </summary>
    public partial class ZeroDPage : Page
    {
        public MainWindowViewModel ViewModel { get; set; }
        public ZeroDPage()
        {
            DataContext = ViewModel = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}
