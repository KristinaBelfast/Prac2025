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
using Prac.Models;

namespace Prac
{
    /// <summary>
    /// Логика взаимодействия для ChangeTechnicWindow.xaml
    /// </summary>
    public partial class ChangeTechnicWindow : Window
    {
        Technic tec_;
        public ChangeTechnicWindow(Technic technic)
        {
            InitializeComponent();
            tec_ = technic;
            Initialize(tec_);
            TypesOfTechnics.ItemsSource = new List<String>
             {
                 "бульдозер",
                 "трактор",
                 "бетономешалка"
             };

        }

        public void Initialize(Technic technic)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                var tec = context.TechnicTypes.Where(t => t.TypeId == technic.TypeId).FirstOrDefault();
                string type = tec.Name;
                YearTextBox.Text = technic.ManufactureYear.ToString();
                TypesOfTechnics.SelectedItem = type;

            }
            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            using (MyDatabaseContext context = new MyDatabaseContext())
            {
                context.Technics.Update(tec_);
                context.SaveChanges();
                this.Close();
            }
        }
    }
}
