using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class TemperatureMeasurement
    {
        
        public decimal Temperature { get; set; }
        public int Id { get; set; }
        public int ApplicationUserId;

        public DateTime MeasureDate { get; set; }
        public Boolean OfficeToday { get; set; }
        public Boolean OfficeTomorrow { get; set; }
    }
}
