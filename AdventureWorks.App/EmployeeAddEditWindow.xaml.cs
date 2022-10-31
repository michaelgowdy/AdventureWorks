using AdventureWorks.Models;
using AdventureWorks.Web.Api.Client;
using System;
using System.Windows;

namespace AdventureWorks.App
{
    /// <summary>
    /// Interaction logic for EmployeeAddEditWindow.xaml
    /// </summary>
    public partial class EmployeeAddEditWindow : Window
    {
        public EmployeeAddEditWindow()
        {
            InitializeComponent();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var id = Convert.ToInt32(addId.Text);
            var job = addJobTitle.Text;

            EmployeeModel newEmployee = new EmployeeModel
            {
                BusinessEntityID = id,
                JobTitle = job
            };

            EmployeeClient.AddEmployeeClient(newEmployee);
        }

        private void UpdateEmployee_Click(object sender, RoutedEventArgs e)
        {
            var id = Convert.ToInt32(updateId.Text);
            var job = updateJobTitle.Text;

            EmployeeModel newEmployee = new EmployeeModel
            {
                BusinessEntityID = id,
                JobTitle = job
            };

            EmployeeClient.UpdateEmployeeClient(newEmployee);
        }
    }
}
