using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Myblog1.Models;
using Myblog1.Data;

namespace Myblog1.ViewComponents
{
    public class TermsListViewComponent : ViewComponent
    {
        private readonly Myblog1Context _context;

        public TermsListViewComponent(Myblog1Context context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            return View(await _context.Terms.ToListAsync());
        }
    }
}
