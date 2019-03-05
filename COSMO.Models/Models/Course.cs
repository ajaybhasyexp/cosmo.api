using Dapper.Contrib.Extensions;
using System;

namespace COSMO.Models.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public string Description { get; set; }

        public int CreatedBy { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
