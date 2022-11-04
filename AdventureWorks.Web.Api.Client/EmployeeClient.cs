using AdventureWorks.Models;
using AdventureWorks.Models.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorks.Web.Api.Client
{
    public class EmployeeClient
    {
        public static RestClient client = new RestClient("https://localhost:44351/employee");
        public static SystemTextJsonSerializer serializer = new SystemTextJsonSerializer();

        public static List<FullEmployeeModel> GetEmployeesClient()
        {
            RestRequest request = new RestRequest();

            RestResponse response = client.Get(request);

            return serializer.Deserialize<List<FullEmployeeModel>>(response);
        }

        public static FullEmployeeModel GetOneEmployeeClient(int id)
        {
            client = new RestClient($"https://localhost:44351/employee/id/{id}");

            RestRequest request = new RestRequest();

            //request.AddParameter("id", id);

            var response = client.Get(request);
            return serializer.Deserialize<List<FullEmployeeModel>>(response).First();


            //return (FullEmployeeModel)response;

            //var responseContent = response.Content.ToString();
            //var employee = JsonConvert.DeserializeObject<FullEmployeeModel>(responseContent);
            //return employee;

            //return employee.Where(x => x.BusinessEntityID == id).First();
        }

        public static void UpdateEmployeeClient(FullEmployeeModel employee)
        {
            var body = new FullEmployeeModel { BusinessEntityID = employee.BusinessEntityID, FirstName = employee.FirstName, LastName = employee.LastName, JobTitle = employee.JobTitle };

            RestRequest request = new RestRequest();

            request.AddJsonBody(body);

            var response = client.Put(request);

            System.Console.WriteLine(response.StatusCode);
        }

        public static void AddEmployeeClient(FullEmployeeModel employee)
        {
            var body = new FullEmployeeModel { FirstName = employee.FirstName, LastName = employee.LastName, JobTitle = employee.JobTitle };

            RestRequest request = new RestRequest();

            request.AddJsonBody(body);

            var response = client.Post(request);

            System.Console.WriteLine(response.StatusCode);
        }

        public static List<FullEmployeeModel> DeleteEmployeeClient(int id)
        {
            RestRequest request = new RestRequest();

            request.AddParameter("id", id);

            var response = client.Delete(request);

            return serializer.Deserialize<List<FullEmployeeModel>>(response);
        }
    }
}
