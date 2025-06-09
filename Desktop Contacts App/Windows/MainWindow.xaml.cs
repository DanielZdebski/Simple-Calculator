using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Desktop_Contacts_App.Classes;
using Desktop_Contacts_App.Windows;
using SQLite;


namespace Desktop_Contacts_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>(); 

            ReadDatabse();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Windows.NewContactWindow newContactWindow = new Windows.NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDatabse();
        }

        void ReadDatabse()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();      // This statement assures there is a table created. 
                contacts = (connection.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();
            }

            if (contacts != null) 
            {
                    contactsListView.ItemsSource = contacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = (TextBox)sender;            // or access the "sender as TextBox

            List<Contact> filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            var filteredList2 = (from c2 in contacts
                                where c2.Name.ToLower().Contains(searchTextBox.Text.ToLower())
                                orderby c2.Email
                                select c2).ToList();

            contactsListView.ItemsSource = filteredList;
        }
    }
}