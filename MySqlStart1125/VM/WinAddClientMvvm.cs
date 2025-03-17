using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlStart1125.Model;

namespace MySqlStart1125.VM
{
    internal class WinAddClientMvvm : BaseVM
    {
        private Client newClient = new();

        public Client NewClient
        {
            get => newClient;
            set
            {
                newClient = value;
                Signal();
            }
        }

        public CommandMvvm InsertClient { get; set; }
        public WinAddClientMvvm()
        {
            InsertClient = new CommandMvvm(() =>
            {
                ClientsDB.GetDb().Insert(NewClient);
                close?.Invoke();
            },
                () =>
                !string.IsNullOrEmpty(newClient.FirstName) &&
                !string.IsNullOrEmpty(newClient.LastName));
        }
        Action close;
        internal void SetClose(Action close)
        {
            this.close = close;
        }
    }
}
