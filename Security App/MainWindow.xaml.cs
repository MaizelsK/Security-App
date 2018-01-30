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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace Security_App
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> employers;
        public Window checkWindow;
        public MainWindow()
        {
            InitializeComponent();
            employers = new ObservableCollection<Employee>();

            employeeDataGrid.ItemsSource = employers;
        }

        //Добавление пользователся
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            employers.Add(new Employee
            {
                Id = new Guid(),
                FullName = "Имя...",
                Position = "Должность..."
            });
        }

        //Удаление пользователся
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            employers.Remove((Employee)employeeDataGrid.SelectedItem);
        }

        //Сохранение данных в формате Json
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string data = JsonConvert.SerializeObject(employers);

            System.IO.File.WriteAllText($@"..\Employers Data\{DateTime.Now.ToShortDateString()}.json", data);
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkWindow == null)
            {
                checkWindow = new CheckWindow(this);
                checkWindow.Show();
            }
        }
    }
}
