using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.HttpSys;

namespace WebApplication2.Models
{
    public class ComplianceRecord
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime MeasureDate { get; set; }
        public string ChecklistName { get; set; }
    }
}
