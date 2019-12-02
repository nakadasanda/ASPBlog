using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Myblog1.Models;
using Myblog1.Data;
using System.Xml.Linq;

namespace Myblog1.Controllers
{
    public class Sitemap
    {
        private readonly Myblog1Context _context;

        public Sitemap(Myblog1Context context)
        {
            _context = context;
            
        }

        public string GetSitemapDocument()
        {
            var term = _context.Posts.ToList();

            XNamespace xmlns = "http://www.sitemaps.org/schemas/sitemap/0.9";
            XElement root = new XElement(xmlns + "urlset");

            foreach (var item in term)
            {
                string url = "https://franprogramerblog.azurewebsites.net/Blog/View/" + item.Id ;

                XElement urlElement = new XElement(
                    xmlns + "url",
                    new XElement(xmlns + "loc", url),
                    new XElement(xmlns + "lastmod", item.PostDate.ToLocalTime().ToString("yyyy-MM-ddTHH:mm:sszzz")),
                    new XElement(xmlns + "changefreq", "monthly"),
                    new XElement(xmlns + "priority", 1));
                    root.Add(urlElement);
            }

            XDocument document = new XDocument(root);
            return document.ToString();

        }
    }
}