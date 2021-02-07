using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShopingCartItemId { get; set; }

        public Pie Pie { get; set; }
        public int Amount { get; set; }
        // This is to record session data 
        public string ShoppingCartId { get; set; }
    }

}
