using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.DependencyInjection;
using PieShop.Data;
using PieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ApplicationDbContext _db;
        ISession session;
        private readonly CustomerRepo _cusrepo;

        public CustomerController(ApplicationDbContext db, IServiceProvider services,CustomerRepo cusrepo)
        {
            _db = db;
            _cusrepo = cusrepo;
            session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
        }
       
        

        //return url. This method captures url that user came from
        public IActionResult Login(string returnUrl="/")
        {

            return View(new Customer { Returnurl = returnUrl }); 
         
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(Customer model)
        {
            var user = _cusrepo.GetByUsernameAndPassword(model.UserName, model.Password);

            if (user == null)
                return Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.CustomerId.ToString()),
                new Claim(ClaimTypes.Name,user.CusName)
                

            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, principal,
                new AuthenticationProperties { IsPersistent = model.RememberLogin });
            return LocalRedirect(model.Returnurl);


        }


        public ActionResult UserDashBoard()
        {
            if (HttpContext.Session.GetString("CustomerId") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }





    }
}