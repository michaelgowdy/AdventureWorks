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

        private void AddEmployee()
        {
            var newEmployee = new FullEmployeeModel
            {
                FirstName = addFirstName.Text,
                LastName = addLastName.Text,
                JobTitle = addJobTitle.Text,
                LoginID = addLoginID.Text,
                NationalIDNumber = addNationalIDNumber.Text
            };

            EmployeeClient.AddEmployeeClient(newEmployee);
        }

        private void UpdateEmployee()
        {
            addUpdateButton.IsEnabled = true;

            FullEmployeeModel newEmployee = new FullEmployeeModel
            {
                BusinessEntityID = Convert.ToInt32(addId.Text),
                FirstName = addFirstName.Text,
                LastName = addLastName.Text,
                JobTitle = addJobTitle.Text,
                LoginID = addLoginID.Text,
                NationalIDNumber = addNationalIDNumber.Text
            };

            EmployeeClient.UpdateEmployeeClient(newEmployee);
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            

            if (Title == "AddEmployeeWindow")
            {
                AddEmployee();
            }
            else
            {
                UpdateEmployee();
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
