using AdventureWorks.Models.Models;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serializers.Json;
using System.Collections.Generic;

namespace AdventureWorks.Web.Api.Client
{
    public class ProductClient
    {
        public static List<ProductModel> GetProductsClient(int pageNumber)
        {
            var serializer = new SystemTextJsonSerializer();

            RestClient client = new RestClient($"https://localhost:44351/product/page{pageNumber}");

            RestRequest request = new RestRequest();

            var response = client.Get(request);

            return serializer.Deserialize<List<ProductModel>>(response);
        }

        public static List<ProductModel> GetOneProductClient(int id)
        {
            var serializer = new SystemTextJsonSerializer();

            RestClient client = new RestClient($"https://localhost:44351/product/{id}");

            RestRequest request = new RestRequest();

            var response = client.Get(request);

            return serializer.Deserialize<List<ProductModel>>(response);
        }

        public static void UpdateProductClient(ProductModel product)
        {
            RestClient client = new RestClient($"https://localhost:44351/product");

            RestRequest request = new RestRequest();

            var body = new ProductModel { ProductID = product.ProductID, Name = product.Name, ProductNumber = product.ProductNumber, Color = product.Color, Size = product.Size, ListPrice = product.ListPrice };

            request.AddJsonBody(body);

            var response = client.Put(request);

            System.Console.WriteLine(response.StatusCode);
        }

        public static void AddProductClient(ProductModel product)
        {
            RestClient client = new RestClient($"https://localhost:44351/product");

            RestRequest request = new RestRequest();
            
            var body = new ProductModel { Name = product.Name, ProductNumber = product.ProductNumber, Color = product.Color, Size = product.Size, ListPrice = product.ListPrice };

            request.AddJsonBody(body);

            var response = client.Post(request);

            System.Console.WriteLine(response.StatusCode);
        }


        public static List<ProductModel> DeleteProductClient(int id)
        {
            var serializer = new SystemTextJsonSerializer();

            RestClient client = new RestClient($"https://localhost:44351/product/{id}");

            RestRequest request = new RestRequest();

            var response = client.Delete(request);

            return serializer.Deserialize<List<ProductModel>>(response);
        }
    }
}
