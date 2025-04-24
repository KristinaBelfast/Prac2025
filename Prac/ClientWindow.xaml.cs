using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Prac.Models;

namespace Prac
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ObservableCollection<Technic> Technics { get; set; }
        public ClientWindow()
        {
            InitializeComponent();
            using (MyDatabaseContext _context = new MyDatabaseContext())
            {
                Technics = new ObservableCollection<Technic>(_context.Technics.ToList());
            }
            DataContext = this;
        }
    }
}
