using System.Configuration;
using System.Data;
using System.Windows;

namespace Desktop_Contacts_App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static internal string databaseName = "Contacts.db";
        static internal string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        static internal string databasePath = System.IO.Path.Combine(folderPath, databaseName);
    }

}
