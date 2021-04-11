using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PieShop.Data;
using PieShop.Models;
using PieShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Controllers
{
    public class CommentController : Controller
    {

        private readonly IComment _comment;

        private readonly ApplicationDbContext b;
        public CommentController(IComment comment,ApplicationDbContext a)
        {
            _comment = comment;
            b = a;
        }


        public ViewResult Index()
        {
            return View();
        }
       
        
        public IActionResult a(int id)
            
        {

            IEnumerable<Pie> pie  = from a in b.Pies
                  where a.PieId == id
                  select a;

            var commentviewmodel = new CommentViewModel
            {
                Pies = pie,

              Comments= _comment.Getcommentlistbyid(id)
            };

           
            return View(commentviewmodel);
        }

        


        public IActionResult Add(int id=0)
        {

            Comment c = new Comment();

            c.PieCollection = _comment.AllPies.ToList();

            return View(c);
        }


        [HttpPost]
        public IActionResult Add(Comment obj)
        {
            
            if (ModelState.IsValid)
            {
                b.Comments.Add(obj);
                b.SaveChanges();

                return RedirectToAction("Index");


            }
            return View(obj);

        }




    }
}
