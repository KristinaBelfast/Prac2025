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
using Prac.Models1;

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
            using(PracticaContext _context = new PracticaContext())
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
            using (PracticaContext context = new PracticaContext())
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
            using (PracticaContext context = new PracticaContext())
            {
                context.Remove(technic);
                Technics.Remove(technic);
                var orders = context.Orders.Where(or => or.TechnicId == technic.TechnicId).ToList();
                foreach (var order in orders)
                {
                    context.RentalAgreements.Where(ra => ra.OrderId == order.OrderId).ExecuteDelete();
                }
                context.MaintenanceRecords.Where(mr => mr.TechnicId == technic.TechnicId).ExecuteDelete();

                context.SaveChanges();

            }
        }
    }
}
