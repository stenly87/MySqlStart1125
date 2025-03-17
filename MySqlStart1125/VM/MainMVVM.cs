using System.Collections.ObjectModel;
using System.Windows;
using MySqlStart1125.Model;

namespace MySqlStart1125.VM
{
    internal class MainMVVM : BaseVM
    {
        private Client selectedClient;
        private ObservableCollection<Client> clients = new();

        public ObservableCollection<Client> Clients
        {
            get => clients;
            set
            {
                clients = value;
                Signal();
            }
        }
        public Client SelectedClient
        {
            get => selectedClient;
            set
            {
                selectedClient = value;
                Signal();
            }
        }
        public CommandMvvm UpdateClient { get; set; }
        public CommandMvvm RemoveClient { get; set; }
        public CommandMvvm AddClient { get; set; }

        public MainMVVM()
        {
            SelectAll();

            UpdateClient = new CommandMvvm(() =>
            {
                if (ClientsDB.GetDb().Update(SelectedClient))
                    MessageBox.Show("Успешно");
            }, () => SelectedClient != null);

            RemoveClient = new CommandMvvm(() =>
            {
                ClientsDB.GetDb().Remove(SelectedClient);
                SelectAll();
            }, () => SelectedClient != null);

            AddClient = new CommandMvvm(() =>
            {
                new WinAddClient().ShowDialog();
                SelectAll();
            }, () => true);
        }

        private void SelectAll()
        {
            Clients = new ObservableCollection<Client>(ClientsDB.GetDb().SelectAll());
        }

    }
}