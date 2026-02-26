using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ApiBlazorWebassembly.Shared.Models
{
    public class ShoppingItem
    {

        public string? MongoId { get; set; }
       
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        public bool HaveBought { get; set; }

        public ShoppingItem(int id = 0, string name="", int quantity=0,bool haveBought=false)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            HaveBought = haveBought;
        }

        public ShoppingItem() { }   

        public override string ToString()
        {
            return $"{Id} {Name} {Quantity} { HaveBought}";
        }

        public void calcSomething()
        {

        }

    }
}
