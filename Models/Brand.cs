using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BicyleStoreAPI.Models
{
    [Table("brands")]
    public partial class Brand
    {
        public Brand()
        {
            Bicycles = new HashSet<Bicycle>();
        }

        [Key]
        [Column("brand_id")]
        public int BrandId { get; set; }
        [Required]
        [Column("brand_name")]
        [StringLength(100)]
        public string BrandName { get; set; }

        [InverseProperty(nameof(Bicycle.Brand))]
        public virtual ICollection<Bicycle> Bicycles { get; set; }
    }
}
