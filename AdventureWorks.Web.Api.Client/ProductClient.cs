using AdventureWorks.Models.Models;
using RestSharp;
using RestSharp.Serializers.Json;
using System;
using System.Collections.Generic;

namespace AdventureWorks.Web.Api.Client
{
    public class ProductClient
    {
        public static RestClient client = new RestClient("https://localhost:44351/product");
        public static SystemTextJsonSerializer serializer = new SystemTextJsonSerializer();

        public static List<ProductModel> GetProductsClient(int page, int pageSize)
        {
            Convert.ToInt32(pageSize);
            RestRequest request = new RestRequest();

            request.AddQueryParameter("page", page);
            request.AddQueryParameter("pageSize", pageSize);

            var response = client.Get(request);

            return serializer.Deserialize<List<ProductModel>>(response);
        }

        public static List<ProductModel> GetOneProductClient(int id)
        {
            RestRequest request = new RestRequest();

            request.AddParameter("id", id);

            var response = client.Get(request);

            return serializer.Deserialize<List<ProductModel>>(response);
        }

        public static void UpdateProductClient(ProductModel product)
        {
            var body = new ProductModel { ProductID = product.ProductID, Name = product.Name, ProductNumber = product.ProductNumber, Color = product.Color, Size = product.Size, ListPrice = product.ListPrice };

            RestRequest request = new RestRequest();

            request.AddJsonBody(body);

            var response = client.Put(request);

            System.Console.WriteLine(response.StatusCode);
        }

        public static void AddProductClient(ProductModel product)
        {
            var body = new ProductModel { Name = product.Name, ProductNumber = product.ProductNumber, Color = product.Color, Size = product.Size, ListPrice = product.ListPrice };

            RestRequest request = new RestRequest();

            request.AddJsonBody(body);

            var response = client.Post(request);

            System.Console.WriteLine(response.StatusCode);
        }


        public static List<ProductModel> DeleteProductClient(int id)
        {
            RestRequest request = new RestRequest();

            request.AddParameter("id", id);

            var response = client.Delete(request);

            return serializer.Deserialize<List<ProductModel>>(response);
        }
    }
}
