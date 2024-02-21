using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IShoppingCart shoppingCart;
        private readonly IOrderRepository orderRepository;

        public OrderController(IShoppingCart shoppingCart, IOrderRepository orderRepository)
        {
            this.shoppingCart = shoppingCart;
            this.orderRepository = orderRepository;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;

            if (shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            if (ModelState.IsValid)
            {
                orderRepository.CreateOrder(order);
                shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}
