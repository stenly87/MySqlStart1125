using System.Collections.ObjectModel;
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

namespace MySqlStart1125
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Client> Clients { get; set; } = new();
        DbConnection db;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            db = new DbConnection();
            ClientsDB clientsDB = new ClientsDB();
            db.SetConnection(clientsDB);

            // пример с добавлением в бд
            //Client client = new Client { FirstName = "Петр", LastName = "Иванов" };
            //clientsDB.Insert(client);

            // пример с получением данных из бд
            var clients = clientsDB.SelectAll();
            // полученную коллекцию выводим в список
            clients.ForEach(s => Clients.Add(s));

            // пример изменения записи
            //var edit = Clients.First();
            //edit.FirstName = "Иван";
            //edit.LastName = "Петров";

            //if (!clientsDB.Update(edit))
            //    MessageBox.Show("Сохранение изменений не срослось");
            //else
            //    MessageBox.Show("Запись изменена");

            // пример удаления записи
            //var remove = Clients.Last();
            //clientsDB.Remove(remove);

        }
    }
}