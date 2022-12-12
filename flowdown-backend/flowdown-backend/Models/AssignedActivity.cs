using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flowdown_backend.Models
{
    public class AssignedActivity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string DueDate { get; set; }
        public int? LessonId { get; set; }
        public string? AssigneeId { get; set; }
    }
}
