using System.Windows;

namespace AdventureWorks.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void employeesButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeListWindow employeeListWindow = new EmployeeListWindow();
            employeeListWindow.Show();

        }

        private void productsButton_Click(object sender, RoutedEventArgs e)
        {
            ProductListWindow productListWindow = new ProductListWindow();
            productListWindow.Show();

            //NEWProductsWindow ProductsWindow = new NEWProductsWindow();
            //ProductsWindow.Show();
        }
    }
}
