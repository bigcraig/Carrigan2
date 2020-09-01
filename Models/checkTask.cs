using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class checkTask
    {
        // Task to provide a many-many join between Task and checklist
        public int UserTaskId { get; set; }
        public UserTask UserTask { get; set; }

        public int ChecklistId { get; set; }
        public Checklist Checklist { get; set; }

    }
}
 