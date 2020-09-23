using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public enum DisplayFormat {Section,Heading,Step,Textbox,LargeTextbox}
    public class Checklist
    {
        public int ID { get; set; }
        public int Sequence { get; set; }
        public DisplayFormat DisplayFormat {get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }

    }
}
