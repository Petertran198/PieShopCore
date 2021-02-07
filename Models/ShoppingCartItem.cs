using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShopingCartItemID { get; set; }

        public Pie Pie { get; set; }
        public int Amount { get; set; }
        // This is to record session data 
        public string ShoppingCartID { get; set; }
    }

}
