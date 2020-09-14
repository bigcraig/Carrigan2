using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.checklistedit
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication2.Data.ApplicationDbContext _context;

        public DetailsModel(WebApplication2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Checklist Checklist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Checklist = await _context.Checklist.FirstOrDefaultAsync(m => m.ID == id);

            if (Checklist == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
