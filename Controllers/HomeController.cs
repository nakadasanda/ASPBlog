using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Myblog1.Models;
using Myblog1.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text;

namespace Myblog1.Controllers
{
    public class HomeController : Controller
    {
        private readonly Myblog1Context _context;

        public HomeController(Myblog1Context context)
        {
            _context = context;
        }

        public async Task<IActionResult>  Index()
        {
            var item = await _context.Posts.OrderByDescending(a => a.Id).ToListAsync();
            return View(item);
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("sitemap.xml")]
        public ActionResult SitemapXml()
        {
            var sitemap = new Sitemap(_context);
            string xml = sitemap.GetSitemapDocument();
            return this.Content(xml);
        }

        [Route("ads.txt")]
        public ActionResult AdsTxt()
        {
            string txt;
            using (var reader = new StreamReader("wwwroot/ads/ads.txt"))
            {
                 txt = reader.ReadToEnd();
            }
            return this.Content(txt);
        }
    }
}
