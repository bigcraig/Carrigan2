﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Pages.Compliance
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication2.Data.ApplicationDbContext _context;

        public IndexModel(WebApplication2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ComplianceRecord> ComplianceRecord { get;set; }

        public async Task OnGetAsync()
        {
            ComplianceRecord = await _context.ComplianceRecord.ToListAsync();
        }
    }
}
