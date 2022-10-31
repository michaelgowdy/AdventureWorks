using AdventureWorks.Models;
using AdventureWorks.Models.Models;
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
            var newEmployee = new FullEmployeeModel();

            newEmployee.FirstName = addFirstName.Text;
            newEmployee.LastName = addLastName.Text;
            newEmployee.JobTitle = addJobTitle.Text;

            if (Title == "AddEmployeeWindow")
            {
                EmployeeClient.AddEmployeeClient(newEmployee);
            }
            else
            {
                newEmployee.BusinessEntityID = Convert.ToInt32(addId.Text);
                EmployeeClient.UpdateEmployeeClient(newEmployee);
            }
        }

        //private void UpdateEmployee_Click(object sender, RoutedEventArgs e)
        //{
        //    //var id = Convert.ToInt32(updateId.Text);
        //    //var job = updateJobTitle.Text;

        //    //EmployeeModel newEmployee = new EmployeeModel
        //    //{
        //    //    BusinessEntityID = id,
        //    //    JobTitle = job
        //    //};

        //    EmployeeClient.UpdateEmployeeClient(newEmployee);
        //}
    }
}
