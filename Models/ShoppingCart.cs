using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class ShoppingCart
    {
        //Session string
        public string ShoppingCartId { get; set; }

        //List to put shopping cart items
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        private readonly AppDbContext _appDbContext;
        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //IServiceProvider services is bringing in all the services 
        public static ShoppingCart GetCart(IServiceProvider services)
        {
           //You have to bring in IHttpContextAccessor to get access to the session 
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            //This gets the database 
            var context = services.GetService<AppDbContext>();

            // If a session key "CartId" is found than use it if not set it to a new id by using guid id generator and set it to string
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            //Set a key name "CartId" to the value of cartID
            session.SetString("CartId", cartId);

            //return a newly created shoppingcart with database and session-id(ShoppingCartId)  passed in
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }



    }

}
