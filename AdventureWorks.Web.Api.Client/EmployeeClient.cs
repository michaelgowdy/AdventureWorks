using AdventureWorks.Models;
using AdventureWorks.Models.Models;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Collections.Generic;

namespace AdventureWorks.Web.Api.Client
{
    public class EmployeeClient
    {
        public static List<FullEmployeeModel> GetEmployeesClient()
        {
            var serializer = new SystemTextJsonSerializer();

            RestClient client = new RestClient("https://localhost:44351/employee");

            RestRequest request = new RestRequest();

            var response = client.Get(request);

            return serializer.Deserialize<List<FullEmployeeModel>>(response);
        }

        public static FullEmployeeModel GetOneEmployeeClient(int id)
        {
            var serializer = new SystemTextJsonSerializer();

            RestClient client = new RestClient($"https://localhost:44351/employee/{id}");

            RestRequest request = new RestRequest();

            var response = client.Get(request);

            return serializer.Deserialize<FullEmployeeModel>(response);
        }

        public static void UpdateEmployeeClient(FullEmployeeModel employee)
        {
            RestClient client = new RestClient($"https://localhost:44351/employee");

            RestRequest request = new RestRequest();

            var body = new FullEmployeeModel { BusinessEntityID = employee.BusinessEntityID, FirstName = employee.FirstName, LastName = employee.LastName, JobTitle = employee.JobTitle };

            request.AddJsonBody(body);

            var response = client.Put(request);

            System.Console.WriteLine(response.StatusCode);
        }

        public static void AddEmployeeClient(FullEmployeeModel employee)
        {
            RestClient client = new RestClient($"https://localhost:44351/employee");

            RestRequest request = new RestRequest();

            var body = new FullEmployeeModel { BusinessEntityID = employee.BusinessEntityID, FirstName = employee.FirstName, LastName = employee.LastName, JobTitle = employee.JobTitle };

            request.AddJsonBody(body);

            var response = client.Post(request);

            System.Console.WriteLine(response.StatusCode);
        }

        public static List<FullEmployeeModel> DeleteEmployeeClient(int id)
        {
            var serializer = new SystemTextJsonSerializer();

            RestClient client = new RestClient($"https://localhost:44351/employee/{id}");

            RestRequest request = new RestRequest();

            var response = client.Delete(request);

            return serializer.Deserialize<List<FullEmployeeModel>>(response);
        }
    }
}
