using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOnline.Models;

namespace RestaurantOnline.Services
{
    public static class CurrentSession
    {
        public static List<CartModel> cart = new List<CartModel>();
        public static ActiveUserModel activeUser = new ActiveUserModel();
        public static List<OrderModel> orders = new List<OrderModel>();

        public static void DeleteFromCart(string numeProdus)
        {
            for (int index = 0; index < cart.Count(); index++)
            {
                if (cart[index].NumeProdus.Equals(numeProdus))
                {
                    cart.Remove(cart[index]);
                    break;
                }

            }
        }
    }
}
