using PieShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class OrderRepo : IOrderRepo
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepo(ApplicationDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder (Order order)
        {
            var shoppingcartitems = _shoppingCart.ShoppingCartItems;
            order.total = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (var item in shoppingcartitems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount =item.Amount,
                    PieId = item.Pie.PieId,
                    Price = item.Pie.Price
                };


                order.OrderDetails.Add(orderDetail);

            }

            _appDbContext.Orders.Add(order);

            _appDbContext.SaveChanges();

        }






    }
}
