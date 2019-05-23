using System.Collections.Generic;
using DellChallenge.D2.Web.Models;
using RestSharp;

namespace DellChallenge.D2.Web.Services
{
    public class ProductService : IProductService
    {
        private const string REST_API = "http://localhost:2534/api";

        public ProductModel Add(NewProductModel newProduct)
        {
            var apiClient = new RestClient(REST_API);
            var apiRequest = new RestRequest("products", Method.POST, DataFormat.Json);
            apiRequest.AddJsonBody(newProduct);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            return apiResponse.Data;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            var apiClient = new RestClient(REST_API);
            var apiRequest = new RestRequest("products", Method.GET, DataFormat.Json);
            var apiResponse = apiClient.Execute<List<ProductModel>>(apiRequest);
            return apiResponse.Data;
        }

        public ProductModel GetById(string id)
        {
            var apiClient = new RestClient(REST_API);
            var apiRequest = new RestRequest($"products/{id}", Method.GET, DataFormat.Json);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            return apiResponse.Data;
        }

        public ProductModel Update(string id, NewProductModel newProduct)
        {
            var apiClient = new RestClient(REST_API);
            var apiRequest = new RestRequest($"products/{id}", Method.PUT, DataFormat.Json);
            apiRequest.AddJsonBody(newProduct);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            return apiResponse.Data;
        }

        public void Delete(string id)
        {
            var apiClient = new RestClient(REST_API);
            var apiRequest = new RestRequest($"products/{id}", Method.DELETE, DataFormat.Json);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
        }
    }
}
