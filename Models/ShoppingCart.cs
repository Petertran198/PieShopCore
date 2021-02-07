using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    //ShoppingCart uses sessions
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

        //IServiceProvider services passed in is bringing in all the services 
        public static ShoppingCart GetCart(IServiceProvider services)
        {
           //You have to bring in IHttpContextAccessor to get access to the session  therefore 
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            //This gets the database 
            var context = services.GetService<AppDbContext>();

            // If a session key "CartId" is found than use it if not set it to a new id by using guid id generator and set it to string
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            //Set a key name "CartId" to the value of cartID
            session.SetString("CartId", cartId);

            //return a newly created shoppingcart with database and set session-id(ShoppingCartId) to cartId
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }


        //Add a pie to a ShoppingCartItem DBset
        public void AddToCart(Pie pie, int amount)
        {
            //Grab the appDbContext.ShoppingCartItems dbset and return the first pie  where the DBset shoppingCartItem.Pie.id is equal to the passed in pie.id and the 
            //shoppingCartItem.ShoppingCartId(SessionId) is the current session(ShoppingCartId) 
            // If no pie was found in session ShoppingCartItem list returns null
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            //if shoppingCartItem can not be found that has the same id and belongs to the same session
            // then we will make a new shoppingCartItem instance where it will have the shoppingCartId(session) be the current ShoppingCartId(session id) and the pie as whatever pie was passed in and set amount to 1 
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1
                };

                //We than add that to our ShoppingCartItems DBset 
                _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                //If pie was found than we just increase the amount attribute by 1 representing us adding 1 more of that pie to the ShoppingCartItem 
                shoppingCartItem.Amount++;
            }

            //We save changes
            _appDbContext.SaveChanges();
        }

        //Return an int for the amount of pie leftover that the user selected after removing one 
        public int RemoveFromCart(Pie pie)
        {
            //Grab the appDbContext.ShoppingCartItems dbset and return the first pie  where the DBset shoppingCartItem.Pie.id is equal to the passed in pie.id and the 
            //shoppingCartItem.ShoppingCartId(SessionId) is the current session(ShoppingCartId) 
            // If no pie was found in session ShoppingCartItem list returns null
            var shoppingCartItem =
                    _appDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);
            
            //Container to hold the amount of that certain pie after we remove one 
            var localAmount = 0;

            //If Pie was found 
            if (shoppingCartItem != null)
            {
                //If more than one of those pie was found
                if (shoppingCartItem.Amount > 1)
                {
                    //decrease the ammount attribute by 1 pie in ShoppingCartItem instance 
                    shoppingCartItem.Amount--;

                    // set the amount to be equal
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    //If that pie has an amount of 1 we remove the pie from ShoppingCartItems DBSet
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            //Save the change 
            _appDbContext.SaveChanges();

            //Return amount of that Pie leftover in our shopping cart 
            return localAmount;
        }


        //Return a list of ShoppingCartItem
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            //Return the ShoppingCartItems list where the DbSet ShoppingCartItems has the same shoppingCartID(session) as the current associated session
            // ?? is used to specify that if the first operand(ShoppingCartItems) is null than the value will be whatever is on the right side. If the first operand is not null than that will be used as the value. 
            return ShoppingCartItems ??
                   (ShoppingCartItems =
                       _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Pie)
                           .ToList());
        }


        //Clear the current session ShoppingCartItems DBset
        public void ClearCart()
        {
            //Get the cart items where the item shoppingCartId is the current session id
            var cartItems = _appDbContext
                .ShoppingCartItems
                .Where(item => item.ShoppingCartId == ShoppingCartId);

            //delete the given cartItems that was found 
            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            // Save Change
            _appDbContext.SaveChanges();
        }


        //Return total of all shoppingcart items of current session
        public decimal GetShoppingCartTotal()
        {
            //Find all the ShoppingCartItems with the associated session, then get the price of the shoppingCartItem and amount and sum it all together
            var total = _appDbContext.ShoppingCartItems.Where(i => i.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Pie.Price * c.Amount).Sum();
            return total;
        }
    }

}
