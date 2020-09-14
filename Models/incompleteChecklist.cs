using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class incompleteChecklist
    {
        [Key] 
        public string username { get; }

        private List<int> incompleteSteps { get; set; }
    }
}
