using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiBlazorWebassembly.Shared.Models;
using ApiBlazorWebassembly.Persistance;

using System.Net;

namespace ApiBlazorWebassembly.Controllers
{

    [ApiController]
    [Route("api/shopapi")]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingRepository Repository = new ShoppingRepository();


        public ShoppingController(IShoppingRepository shoppingRepository)
        {
            if (Repository == null && shoppingRepository!=null)
            {   
                    Repository = shoppingRepository;
                    Console.WriteLine("Repository initialized");
            }
        }


        [HttpGet]
        public IEnumerable<ShoppingItem> GetAllItems()
        {
            return Repository.GetAllItems();
        }

        [HttpDelete("{id:int}")]
        public StatusCodeResult DeleteItem(int id)
        {
            Console.WriteLine("Server: Delete item called: id = "+id);

            bool deleted =  Repository.DeleteItem(id);
            if (deleted)
            {
                Console.WriteLine("Server: Item deleted succces");
                int code = (int)HttpStatusCode.OK;
                return new StatusCodeResult(code);
            }
            else
            {
                Console.WriteLine("Server: Item deleted fail - not found");
                int code = (int)HttpStatusCode.NotFound;
                return new StatusCodeResult(code);
            }
        }

        [HttpPost]
        public void AddItem(ShoppingItem item)
        {
            Console.WriteLine("Add item called: "+item.ToString());
            Repository.AddItem(item);
        }


        
       [HttpGet("{id:int}")]
        public ShoppingItem FindItem(int id)
        {  
           var result = Repository.FindItem(id);
           return result;
        }

        [HttpPut]
        public void Update(ShoppingItem item)
        {
            Repository.UpdateItem(item);
        }

    }
}
