using DellChallenge.D2.Web.Models;
using RestSharp;
using System.Collections.Generic;

namespace DellChallenge.D2.Web.Services
{
    public class ProductService : IProductService
    {
        private const string REST_API = "http://localhost:5000/api";
        private const string RESOURCE_NAME = "products";
        private readonly RestClient _apiClient;

        public ProductService()
        {
            _apiClient = new RestClient(REST_API);
        }

        public ProductModel Add(NewProductModel newProduct)
        {
            return Execute<ProductModel, NewProductModel>(RESOURCE_NAME, Method.POST, newProduct);
        }

        public IEnumerable<ProductModel> GetAll()
        {
            return Execute<List<ProductModel>>(RESOURCE_NAME, Method.GET);
        }

        public ProductModel GetById(string id)
        {
            return Execute<ProductModel>($"{RESOURCE_NAME}/{id}", Method.GET);
        }

        public ProductModel Update(string id, NewProductModel newProduct)
        {
            return Execute<ProductModel, NewProductModel>($"{RESOURCE_NAME}/{id}", Method.PUT, newProduct);
        }

        public void Delete(string id)
        {
            Execute($"{RESOURCE_NAME}/{id}", Method.DELETE);
        }

        private T Execute<T>(string url, Method method, T model) where T : new()
        {
            return Execute<T, T>(url, method, model);
        }

        private T Execute<T>(string url, Method method) where T : new()
        {
            return Execute<T>(url, method, default(T));
        }

        private T1 Execute<T1, T2>(string url, Method method, T2 model) where T1 : new() where T2 : new()
        {
            var apiRequest = new RestRequest(url, method, DataFormat.Json);
            if (model != null)
            {
                apiRequest.AddJsonBody(model);
            }

            var apiResponse = _apiClient.Execute<T1>(apiRequest);
            return apiResponse.Data;
        }

        private void Execute(string url, Method method)
        {
            Execute<bool>(url, method);
        }
    }
}
