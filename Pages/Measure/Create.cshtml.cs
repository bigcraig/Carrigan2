using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.Measure
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication2.Data.ApplicationDbContext _context;
        public string username;
        public string applicationUserId;
        public CreateModel(WebApplication2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // determine who is logged in
            username = HttpContext.User.Identity.Name;
            Models.ApplicationUser selectedUser =
                _context.ApplicationUser.FirstOrDefault(c => c.Email == username);

            applicationUserId = selectedUser.Id;
            return Page();
        }

        [BindProperty]
        public TemperatureMeasurement TemperatureMeasurement { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            username = HttpContext.User.Identity.Name;
            Models.ApplicationUser selectedUser =
                _context.ApplicationUser.FirstOrDefault(c => c.Email == username);

            TemperatureMeasurement.ApplicationUserId = selectedUser.Id;
            _context.TemperatureMeasurement.Add(TemperatureMeasurement);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
