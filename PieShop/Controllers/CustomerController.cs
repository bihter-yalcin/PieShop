using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.DependencyInjection;
using PieShop.Data;
using PieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    public class CustomerController : Controller
    {



        private readonly ApplicationDbContext _db;
        ISession session;


        public CustomerController(ApplicationDbContext db, IServiceProvider services)
        {
            _db = db;

            session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
        }
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(Customer objCustomer)
        {       
                
             
            if (ModelState.IsValid)
            {   
                var obj =
               _db.Customers.Where(a => a.UserName.Equals(objCustomer.UserName) && a.Password.Equals(objCustomer.Password))
               .FirstOrDefault();


               

                if (obj != null)
                { var a = obj.CustomerId.ToString();
                var b = obj.CusName.ToString();
                    HttpContext.Session.SetString("CustomerId", a);
                    HttpContext.Session.SetString("UserName", b);
                    return RedirectToAction("UserDashBoard");
                   
                }



            }
           
             return View(objCustomer);
           
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