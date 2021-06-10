using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepo _orderRepo;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepo orderRepo, ShoppingCart shoppingCart)
        {
            _orderRepo = orderRepo;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Create()
        {
            return View();

        }


        [HttpPost]
        public IActionResult Create(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            if (ModelState.IsValid)
            {
                _orderRepo.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("OrderComplete");
            }
            return View(order);
        }


        public IActionResult OrderComplete()
        {
            return View();
        }

    }
}
