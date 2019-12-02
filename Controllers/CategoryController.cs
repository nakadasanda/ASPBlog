using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Myblog1.Data;
using Microsoft.EntityFrameworkCore;

namespace Myblog1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Myblog1Context _context;

        public CategoryController(Myblog1Context context)
        {
            _context = context;
        }
        public IActionResult Index(int? id)
        {
            var item = (from r in _context.Relations
                        join p in _context.Posts
                        on r.Post equals p
                        join t in _context.Terms
                        on r.Term equals t
                        where t.Id == id
                        orderby p.Id descending
                        select p).ToArray();


            return View(item);
        }
    }
}