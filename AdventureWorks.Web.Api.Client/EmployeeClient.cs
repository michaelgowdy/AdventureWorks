using AdventureWorks.Models;
using AdventureWorks.Models.Models;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Collections.Generic;

namespace AdventureWorks.Web.Api.Client
{
    public class EmployeeClient
    {
        public static List<EmployeeModel> GetEmployeesClient()
        {
            var serializer = new SystemTextJsonSerializer();

            RestClient client = new RestClient("https://localhost:44351/employee");

            RestRequest request = new RestRequest();

            var response = client.Get(request);

            return serializer.Deserialize<List<EmployeeModel>>(response);
        }

        public static EmployeeModel GetOneEmployeeClient(int id)
        {
            var serializer = new SystemTextJsonSerializer();

            RestClient client = new RestClient($"https://localhost:44351/employee/{id}");

            RestRequest request = new RestRequest();

            var response = client.Get(request);

            return serializer.Deserialize<EmployeeModel>(response);
        }

        public static void UpdateEmployeeClient(EmployeeModel employee)
        {
            RestClient client = new RestClient($"https://localhost:44351/employee");

            RestRequest request = new RestRequest();

            var body = new EmployeeModel { BusinessEntityID = employee.BusinessEntityID, JobTitle = employee.JobTitle };

            request.AddJsonBody(body);

            var response = client.Put(request);

            System.Console.WriteLine(response.StatusCode);
        }

        public static void AddEmployeeClient(EmployeeModel employee)
        {
            RestClient client = new RestClient($"https://localhost:44351/employee");

            RestRequest request = new RestRequest();

            var body = new EmployeeModel { BusinessEntityID = employee.BusinessEntityID, JobTitle = employee.JobTitle };

            request.AddJsonBody(body);

            var response = client.Post(request);

            System.Console.WriteLine(response.StatusCode);
        }

        public static List<EmployeeModel> DeleteEmployeeClient(int id)
        {
            var serializer = new SystemTextJsonSerializer();

            RestClient client = new RestClient($"https://localhost:44351/employee/{id}");

            RestRequest request = new RestRequest();

            var response = client.Delete(request);

            return serializer.Deserialize<List<EmployeeModel>>(response);
        }
    }
}
