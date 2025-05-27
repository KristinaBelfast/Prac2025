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
using Microsoft.EntityFrameworkCore;
using Prac.Models1;

namespace Prac
{
    /// <summary>
    /// Логика взаимодействия для AddTechnicWindow.xaml
    /// </summary>
    public partial class AddTechnicWindow : Window
    {
        public AddTechnicWindow()
        {
            InitializeComponent();
            TypesOfTechnics.ItemsSource = new List<String>
            {
              "Дрэгстеры",
                 "Кросс-байки",
                 "Мини-байки",
                 "Питбайки",
                 "Мотарды"
             };

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (PracticaContext context = new PracticaContext())
            {
                string type_ = TypesOfTechnics.SelectedItem.ToString();
                TechnicType type = context.TechnicTypes.Where(t => t.Name == type_).FirstOrDefault();
                Technic newTechnic = new Technic
                {
                    ManufactureYear = int.Parse(YearTextBox.Text),
                    TypeId = type.TypeId,
                    AvailabilityId = 1
                };
                context.Technics.Add(newTechnic);
                context.SaveChanges();
                MessageBox.Show("Техника добавлена!");
                this.Close();
            }
        }
    }
}
