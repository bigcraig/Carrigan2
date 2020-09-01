using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Checklist
    {
        public Checklist()
        {
            
        }
        public int ID { get; set; }
        public string Name { get; set; }
        private int CompanyID { get; set; }

        public List<checkTask> CheckTasks { get; set; }
    }
}
