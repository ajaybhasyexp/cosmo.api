using System;

namespace COSMO.Models.User
{
    /// <summary>
    /// The Offering Model.
    /// </summary>
    public class Offering
    {
        public int OfferingId { get; set; }

        public string OfferingName { get; set; }

        public int TempleId { get; set; }

        public int OfferingGroupId { get; set; }

        public string OfferingGroupName { get; set; }

        public decimal Price { get; set; }

        public string DeityName { get; set; }

        public int DeityId { get; set; }

        public string OfferingCode { get; set; }

        public int MaxPerDay { get; set; }

        public bool IsBookable { get; set; }

        public int UpdatedBy { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }        
    }
}
