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

namespace Security_App
{
    /// <summary>
    /// Логика взаимодействия для CheckWindow.xaml
    /// </summary>
    public partial class CheckWindow : Window
    {
        MainWindow mainWindow;
        ObservableCollection<Employee> employers;
        public CheckWindow(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            employers = mainWindow.employers;

            InitializeComponent();

            employeeCheckGrid.ItemsSource = employers;

            datePicker.SelectedDate = DateTime.Today;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var employee in employers)
            {
                employee.IsArrived = employee.CheckVisit(datePicker.SelectedDate.Value);
            }
        }

        private void EmployeeCheckGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            CheckBox checkBox = employeeCheckGrid.Columns[3].GetCellContent(employeeCheckGrid.SelectedItem) as CheckBox;

            if (datePicker.SelectedDate != null)
            {
                if (checkBox.IsChecked == true)
                {
                    employers[employeeCheckGrid.SelectedIndex].Visits.Add(datePicker.SelectedDate.Value);
                }
                else
                {
                    employers[employeeCheckGrid.SelectedIndex].Visits.Remove(datePicker.SelectedDate.Value);
                }
            }
        }
    }
}
