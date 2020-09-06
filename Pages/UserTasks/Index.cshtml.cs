
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.UserTasks
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.ApplicationDbContext _context;
        public SelectList ChecklistSelectList { get; set; }
        [BindProperty]
        public String  SelectedCheckListName { get; set; }
        public IndexModel(WebApplication2.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        private void PopulateCheckLists(WebApplication2.Data.ApplicationDbContext _context)
        {
            var checkLists = from c in _context.Checklist
                orderby c.Name
                select c;
            ChecklistSelectList = new SelectList(checkLists, "Name", "Name");
        }
        public IList<UserTask> UserTask { get;set; }
        public IList<Checklist> CheckLists { get; set; }

        public async Task OnGetAsync()
        {  
            PopulateCheckLists(_context);
           // UserTask = await _context.UserTask.Where(t=>t.ID==1).ToListAsync();
            UserTask = await _context.UserTask.ToListAsync();
           // CheckLists = await _context.Checklist.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var checklisttest = await _context.Checklist.ToListAsync();
           // var selectedCheckList = await _context.Checklist.Where(s => s.ID == 2)
           //     .FirstOrDefaultAsync();
            //var selectedCheckListID = selectedCheckList.ID;
                UserTask = await _context.UserTask.Where(t => t.ID == 1007).ToListAsync();
          //  UserTask = await _context.UserTask.ToListAsync();
            return Page();
            
        }
    }
}
