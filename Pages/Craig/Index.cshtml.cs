using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.Craig
{[BindProperties]
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.ApplicationDbContext _context;
        public IList<bool> Answers { set; get; }
        public IndexModel(WebApplication2.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        public List<UserTask> UserTask { get; set; }

        public int globalCounter = 0;

        public async Task OnGetAsync()
        {
            UserTask = await _context.UserTask.ToListAsync();
            Answers = new List<bool>(UserTask.Count);
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var retunedtask = UserTask;

            foreach (var check in UserTask)
            {
                if (check.Completed == false) globalCounter = 1;
            }

            if (globalCounter > 0)
            {
                return RedirectToPage("./errorChecklist");
            }
           
            return Page();
        }
    }
}
