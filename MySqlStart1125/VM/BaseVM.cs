using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MySqlStart1125.VM
{
    internal class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void Signal([CallerMemberName] string prop = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}