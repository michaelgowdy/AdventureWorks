using AdventureWorks.Models.Models;
using RestSharp;
using RestSharp.Serializers.Json;
using System;
using System.Collections.Generic;

namespace AdventureWorks.Web.Api.Client
{
    public class SalesClient
    {
        public static RestClient client = new RestClient("https://localhost:44351/sales");
        public static SystemTextJsonSerializer serializer = new SystemTextJsonSerializer();

        public static List<FullSalesModel> GetSalesClient(int page, int pageSize)
        {
            //RestClient client = new RestClient("https://localhost:44351/sales");
            //Convert.ToInt32(pageSize);
            RestRequest request = new RestRequest();

            request.AddQueryParameter("page", page);
            request.AddQueryParameter("pageSize", pageSize);

            var response = client.Get(request);

            return serializer.Deserialize<List<FullSalesModel>>(response);
        }

        public static FullSalesModel GetOneSaleClient(int id)
        {
            RestClient client = new RestClient($"https://localhost:44351/sales/id/{id}");

            RestRequest request = new RestRequest();

            var response = client.Get(request);

            request.AddQueryParameter("id", id);

            return serializer.Deserialize<FullSalesModel>(response);
        }

        public static void UpdateSaleClient(FullSalesModel newSale)
        {
            RestClient client = new RestClient("https://localhost:44351/sales");

            var body = new FullSalesModel
            { 
                SalesOrderID = newSale.SalesOrderID, 
                OrderDate = newSale.OrderDate, 
                BillToAddressID = newSale.BillToAddressID, 
                ShipToAddressID = newSale.ShipToAddressID, 
                SalesOrderNumber = newSale.SalesOrderNumber,
                SubTotal = newSale.SubTotal,
                TaxAmt = newSale.TaxAmt,
                Freight = newSale.Freight,
                SalesOrderDetailID = newSale.SalesOrderDetailID,
                OrderQty = newSale.OrderQty,
                ProductID = newSale.ProductID,
                SpecialOfferID = newSale.SpecialOfferID,
                UnitPrice = newSale.UnitPrice,
                UnitPriceDiscount = newSale.UnitPriceDiscount
            };

            RestRequest request = new RestRequest();

            request.AddJsonBody(body);


            var response = client.Put(request);

            System.Console.WriteLine(response.StatusCode);
        }

        //     var baseUrl = "someurl from config";
        //     var client = new RestClient(baseUrl);
        //     var request = new RestRequest("/api/saverperson/{name}/{fathername}", Method.POST);
        //     request.RequestFormat = DataFormat.Json;
        //request.AddParameter("Application/Json", myObject, ParameterType.RequestBody);
        //request.AddUrlSegment("name","Gaurav");
        //request.AddUrlSegment("fathername","Lt. Sh. Ramkrishan");

        //var response = client.Execute(request);

        public static void AddSaleClient(FullSalesModel newSale)
        {
            //RestClient client = new RestClient("https://localhost:44351/sales");

            var body = new FullSalesModel
            {
                OrderDate = newSale.OrderDate,
                BillToAddressID = newSale.BillToAddressID,
                ShipToAddressID = newSale.ShipToAddressID,
                SubTotal = newSale.SubTotal,
                TaxAmt = newSale.TaxAmt,
                Freight = newSale.Freight,
                OrderQty = newSale.OrderQty,
                ProductID = newSale.ProductID,
                SpecialOfferID = newSale.SpecialOfferID,
                UnitPrice = newSale.UnitPrice,
                UnitPriceDiscount = newSale.UnitPriceDiscount
            };

            RestRequest request = new RestRequest();

            //request.RequestFormat = DataFormat.Json;
            //request.AddParameter("Application/Json", body, ParameterType.RequestBody);

            request.AddJsonBody(body);
            //request.AddObject(body);

            var response = client.Post(request);

            System.Console.WriteLine(response.StatusCode);
        }

        public static void DeleteSaleClient(int id)
        {
            RestClient client = new RestClient("https://localhost:44351/sales");

            RestRequest request = new RestRequest($"id/{id}", Method.Delete);

            request.AddParameter("id", id);

            var response = client.Delete(request);

            Console.WriteLine(response.StatusCode);
        }
    }
}