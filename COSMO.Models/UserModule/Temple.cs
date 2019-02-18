using System;

namespace COSMO.Models.User
{
    public class Temple
    {
        public int TempleId { get; set; }

        public string TempleName { get; set; }

        public string ContactPerson { get; set; }

        public string ContactNumber { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
