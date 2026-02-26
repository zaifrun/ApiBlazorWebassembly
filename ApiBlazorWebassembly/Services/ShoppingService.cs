//inject HttpClient Http;
using ApiBlazorWebassembly.Shared.Models;
using System.Net.Http;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace ApiBlazorWebassembly.Services
{



    public class ShoppingService: IShoppingService
    {

        private readonly HttpClient httpClient;
        private string baseAPIURL = "https://localhost:7021/"; 

        public ShoppingService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }



        public async Task<int> AddItem(ShoppingItem item)
        {
            var response = await httpClient.PostAsJsonAsync(baseAPIURL+"api/shopapi", item);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;      
        }


        public async Task<int> DeleteItem(int id)
        {
            var response = await httpClient.DeleteAsync(baseAPIURL+"api/shopapi/"+id);
             var responseStatusCode = response.StatusCode;
             return (int)responseStatusCode;
          //  throw new NotImplementedException();
        }

        public async Task<ShoppingItem> GetItem(int id)
        {
            var result = await httpClient.GetFromJsonAsync<ShoppingItem>(baseAPIURL + "api/shopapi/" + id);
            return result;
        }



        public Task<ShoppingItem[]?> GetAllItems()
        {
            //Fra server
          var result = httpClient.GetFromJsonAsync<ShoppingItem[]>(baseAPIURL + "api/shopapi");
            //fra local json fil
          // var result = httpClient.GetFromJsonAsync<ShoppingItem[]>("sample-data/shoppingdata.json");
            return result;
        }


        

        public async Task<int> UpdateItem(ShoppingItem item)
        {
            var response = await httpClient.PutAsJsonAsync(baseAPIURL+"api/shopapi", item);
            var responseStatusCode = response.StatusCode;
            return (int)responseStatusCode;

        }

    }
}
