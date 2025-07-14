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
using System.Windows.Shapes;
using _06_CommunityToolkit_example.ViewModel;

namespace _06_CommunityToolkit_example.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel ViewModel => (MainWindowViewModel)ViewModel;
        public MainWindow()
        {
            //            DataContext = ViewModel = new MainWindowViewModel();
            DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}
