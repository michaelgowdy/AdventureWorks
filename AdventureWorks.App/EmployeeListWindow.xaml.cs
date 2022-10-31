using AdventureWorks.Models;
using AdventureWorks.Web.Api.Client;
using System.Windows;

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
            EmployeeData.ItemsSource = EmployeeClient.GetEmployeesClient();
        }

        private void LoadEmployees_Click(object sender, RoutedEventArgs e)
        {
            EmployeeData.ItemsSource = EmployeeClient.GetEmployeesClient();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var selected = EmployeeData.SelectedItem as EmployeeModel;
            EmployeeAddEditWindow employeeAddEditWindow = new EmployeeAddEditWindow();
            employeeAddEditWindow.UpdateEmployeeGrid.DataContext = selected;
            employeeAddEditWindow.Show();
        }

        private void UpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            var selected = EmployeeData.SelectedItem as EmployeeModel;
            EmployeeAddEditWindow employeeAddEditWindow = new EmployeeAddEditWindow();
            employeeAddEditWindow.UpdateEmployeeGrid.DataContext = selected;
            employeeAddEditWindow.Show();
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeModel selected = EmployeeData.SelectedItem as EmployeeModel;

            var id = selected.BusinessEntityID;

            EmployeeClient.DeleteEmployeeClient(id);
        }

    }
}
