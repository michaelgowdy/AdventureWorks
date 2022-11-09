using AdventureWorks.Models;
using AdventureWorks.Models.Models;
using AdventureWorks.Web.Api.Client;
using System.Windows;
using System.Windows.Controls;

namespace AdventureWorks.App
{
    /// <summary>
    /// Interaction logic for EmployeeListWindow.xaml
    /// </summary>
    public partial class EmployeeListWindow : Window
    {

        public EmployeeListWindow()
        {
            InitializeComponent();
            GetEmployees();
        }

        private void GetEmployees()
        {
            EmployeeDataGrid.ItemsSource = EmployeeClient.GetEmployeesClient();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            EmployeeDataGrid.ItemsSource = EmployeeClient.GetEmployeesClient();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeAddEditWindow employeeAddEditWindow = new EmployeeAddEditWindow();
            employeeAddEditWindow.Show();
        }

        private void UpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeAddEditWindow employeeAddEditWindow = new EmployeeAddEditWindow();
            var selected = EmployeeDataGrid.SelectedItem as FullEmployeeModel;
            employeeAddEditWindow.Title = "EditEmployeeWindow";
            employeeAddEditWindow.addUpdateWindow.Content = "Edit Employee Data";
            employeeAddEditWindow.addUpdateButton.Content = "Update";
            employeeAddEditWindow.AddNewEmployeeGrid.DataContext = selected;
            employeeAddEditWindow.Show();
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            FullEmployeeModel selected = EmployeeDataGrid.SelectedItem as FullEmployeeModel;

            var id = selected.BusinessEntityID;

            try
            {
                EmployeeClient.DeleteEmployeeClient(id);

                EmployeeDataGrid.ItemsSource = EmployeeClient.GetEmployeesClient();
            }
            catch
            {
                MessageBox.Show("Delete cannot process. That product record is being used elsewhere.", "Final Project", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

    }
}
