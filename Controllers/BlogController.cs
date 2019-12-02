using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Markdig;
using Myblog1.Models;
using Myblog1.Data;
namespace Myblog1.Controllers
{
    public class BlogController : Controller
    {
        private readonly Myblog1Context _context;

        public BlogController(Myblog1Context context)
        {
            _context = context;
        }
        public IActionResult View(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _context.Posts.Find(id);
            
            if (post == null)
            {
                return NotFound();
            }

            string content = post.Content;

            var html = Markdown.ToHtml(content);
            ViewBag.html = html;
            return View(post);
        }
    }
}