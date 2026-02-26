using ApiBlazorWebassembly.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  ApiBlazorWebassembly.Services
{
    public interface IShoppingService
    {


        Task<ShoppingItem[]?> GetAllItems();

        Task<ShoppingItem?> GetItem(int id);

        Task<int> AddItem(ShoppingItem item);
        Task<int> DeleteItem(int id);
        Task<int> UpdateItem(ShoppingItem item);


    }
}
