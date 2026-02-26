using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiBlazorWebassembly.Shared.Models;

namespace ApiBlazorWebassembly.Persistance
{
    public interface IShoppingRepository
    {
        List<ShoppingItem> GetAllItems();
        ShoppingItem FindItem(int id);
        void AddItem(ShoppingItem item);
        bool DeleteItem(int id);
        bool UpdateItem(ShoppingItem item);

    }
}
