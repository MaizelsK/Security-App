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
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(var employee in employers)
            {
                foreach(var date in employee.Visits)
                {
                    if (date.ToShortDateString().Equals(datePicker.SelectedDate.Value.ToShortDateString()))
                    {
                        //checkBox.
                    }
                }
            }
        }
    }
}
