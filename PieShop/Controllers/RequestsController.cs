using Microsoft.AspNetCore.Mvc;
using PieShop.Data;
using PieShop.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    public class RequestsController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;

        public RequestsController(ApplicationDbContext applicationDbContext)
        {
            _appDbContext = applicationDbContext;
        }

        public IActionResult Index()
        {

            IEnumerable<Requests> objList = _appDbContext.Requests;
            return View(objList);
        }
        public IActionResult Create()
        {

            return View();
        }

        //POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken] //this is for security
        public IActionResult Create(Requests obj)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Requests.Add(obj);
                _appDbContext.SaveChanges();

               return RedirectToAction("Index");


            }
            return View(obj);

        }


    }
}
