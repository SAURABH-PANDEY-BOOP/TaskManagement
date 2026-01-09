using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.TaskManagment
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string? TaskTitle { get; set; }
        public string? TaskDescription { get; set; }
        public DateTime? TaskDueDate { get; set; }
        public string? TaskStatus { get; set; }
        public string? TaskRemarks { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public int CreatedById { get; set; }
        public string ?CreatedByName { get; set; }

        public int? UpdatedById { get; set; }
        public string? UpdatedByName { get; set; }
    }
}
