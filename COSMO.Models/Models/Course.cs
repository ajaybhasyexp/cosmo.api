using Dapper.Contrib.Extensions;
using System;

namespace COSMO.Models.Models
{
    public class Course : Base
    {
       // [Key]
        //public int CourseId { get; set; }

        public string CourseName { get; set; }

        public string Description { get; set; }
        
    }
}
