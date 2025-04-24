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
using Microsoft.EntityFrameworkCore;
using Prac.Models;

namespace Prac
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public ObservableCollection<Technic> Technics { get; set; }
        public AdminWindow()
        {
            InitializeComponent();
            using(MyDatabaseContext _context = new MyDatabaseContext())
            {
                Technics = new ObservableCollection<Technic>(_context.Technics.ToList());
            }
            GridTechnics.ItemsSource = Technics;

        }


        private void AddTechnicButton_Click(object sender, RoutedEventArgs e)
        {
            AddTechnicWindow addTechnicWindow = new AddTechnicWindow();
            addTechnicWindow.ShowDialog();

            Technics.Clear();
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                foreach (var technic in context.Technics.ToList())
                {
                    Technics.Add(technic);
                }
            }
            
        }

        private void EditTechnicButton_Click(object sender, RoutedEventArgs e)
        {
            Technic technic = (Technic)GridTechnics.SelectedItem;
            ChangeTechnicWindow window = new ChangeTechnicWindow(technic);
            window.ShowDialog();

        }

        private void DeleteTechnicButton_Click(object sender, RoutedEventArgs e)
        {
            Technic technic = (Technic)GridTechnics.SelectedItem;
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                context.Remove(technic);
                Technics.Remove(technic);
                context.SaveChanges();
            }
        }
    }
}
