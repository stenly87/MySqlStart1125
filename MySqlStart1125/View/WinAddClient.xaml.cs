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
using MySqlStart1125.VM;

namespace MySqlStart1125
{
    /// <summary>
    /// Логика взаимодействия для WinAddClient.xaml
    /// </summary>
    public partial class WinAddClient : Window
    {
        public WinAddClient()
        {
            InitializeComponent();
            // сохраняем в вьюмодель ссылку на метод закрытия окна
            ((WinAddClientMvvm)this.DataContext).SetClose(Close);
        }
    }
}
