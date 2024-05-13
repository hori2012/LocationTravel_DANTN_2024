namespace LocationTravel.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Location")]
    public partial class Location
    {
        public int LocationId { get; set; }

        [StringLength(250)]
        public string NameLocation { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public string Description { get; set; }

        [StringLength(200)]
        public string SpecificType { get; set; }

        public byte[] Image { get; set; }

        public decimal? Cost { get; set; }

        public string Link { get; set; }

        public int? AreaId { get; set; }

        public int? TypeId { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public virtual Area Area { get; set; }

        public virtual TypeLocation TypeLocation { get; set; }
    }
}
