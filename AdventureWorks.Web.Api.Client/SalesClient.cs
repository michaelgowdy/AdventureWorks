using AdventureWorks.Models.Models;
using RestSharp;
using RestSharp.Serializers.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks.Web.Api.Client
{
    public class SalesClient
    {
        //public static RestClient client = new RestClient("https://localhost:44351/sales");
        public static SystemTextJsonSerializer serializer = new SystemTextJsonSerializer();

        public static List<SalesOrderHeaderModel> GetSalesClient(int page, int pageSize)
        {
            RestClient client = new RestClient("https://localhost:44351/sales");
            //Convert.ToInt32(pageSize);
            RestRequest request = new RestRequest();

            request.AddQueryParameter("page", page);
            request.AddQueryParameter("pageSize", pageSize);

            var response = client.Get(request);

            return serializer.Deserialize<List<SalesOrderHeaderModel>>(response);
        }

        public static SalesOrderHeaderModel GetOneSaleClient(int id)
        {
            RestClient client = new RestClient($"https://localhost:44351/sales/id/{id}");

            RestRequest request = new RestRequest();

            var response = client.Get(request);

            request.AddQueryParameter("id", id);

            return serializer.Deserialize<SalesOrderHeaderModel>(response);
        }

        public static void UpdateSaleClient(SalesOrderHeaderModel newSale)
        {
            RestClient client = new RestClient("https://localhost:44351/sales");

            var body = new SalesOrderHeaderModel { SalesOrderID = newSale.SalesOrderID, OrderDate = newSale.OrderDate, BillToAddressID = newSale.BillToAddressID, ShipToAddressID = newSale.ShipToAddressID, TotalDue = newSale.TotalDue };

            RestRequest request = new RestRequest();

            request.AddJsonBody(body);

            var response = client.Put(request);

            System.Console.WriteLine(response.StatusCode);
        }

        public static void AddSaleClient(SalesOrderHeaderModel newSale)
        {
            RestClient client = new RestClient("https://localhost:44351/sales");

            var body = new SalesOrderHeaderModel { OrderDate = newSale.OrderDate, BillToAddressID = newSale.BillToAddressID, ShipToAddressID = newSale.ShipToAddressID, TotalDue = newSale.TotalDue };

            RestRequest request = new RestRequest();

            request.AddJsonBody(body);

            var response = client.Post(request);

            System.Console.WriteLine(response.StatusCode);
        }
    }
}
