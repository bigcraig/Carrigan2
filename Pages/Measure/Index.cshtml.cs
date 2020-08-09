using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.Measure
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.ApplicationDbContext _context;

        public IndexModel(WebApplication2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TemperatureMeasurement> TemperatureMeasurement { get;set; }
        public string GetLoggedInUserId(ApplicationDbContext context)
        {
            var _context = context;
            string username = HttpContext.User.Identity.Name;
            Models.ApplicationUser selectedUser =
                _context.ApplicationUser.FirstOrDefault(c => c.Email == username);

            return selectedUser.Id;
        }

        public async Task OnGetAsync()
        {
           string loggedInUserID = GetLoggedInUserId(_context);
            TemperatureMeasurement = await _context.TemperatureMeasurement.Where(c=>c.ApplicationUserId==loggedInUserID).ToListAsync();
        }
    }
}
