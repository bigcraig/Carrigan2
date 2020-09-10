using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.CheckList
{[BindProperties]
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.ApplicationDbContext _context;

        public IndexModel(WebApplication2.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IList<Checklist> Checklist { get;set; }

         public ComplianceRecord ComplianceRecord { get; set; }
         private String username { get; set; }
         private int globalCounter { get; set; }

         public async Task OnGetAsync()
        {
            Checklist = await _context.Checklist.ToListAsync();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            globalCounter = 0;

            foreach (var check in Checklist)
            {
                if ((check.Completed == false) & (check.DisplayFormat ==DisplayFormat.Step )) globalCounter = 1;
            }

            if (globalCounter > 0)
            {
                return RedirectToPage("./errorChecklist");
            }
            // all is good here
            username = HttpContext.User.Identity.Name;
         

            ComplianceRecord.Email = username;
            ComplianceRecord.ChecklistName = "checklist 1";

            var utcTime = DateTime.UtcNow;
            ComplianceRecord.MeasureDate = TimeZoneInfo.ConvertTime(DateTime.Now,
                TimeZoneInfo.FindSystemTimeZoneById("AUS Eastern Standard Time"));


            _context.ComplianceRecord.Add(ComplianceRecord);
            _context.SaveChanges();

            return RedirectToPage("/index");
        }
    }
}

