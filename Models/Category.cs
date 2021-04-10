using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BicyleStoreAPI.Models
{
    [Table("category")]
    public partial class Category
    {
        public Category()
        {
            Bicycles = new HashSet<Bicycle>();
        }

        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Required]
        [Column("category_name")]
        [StringLength(100)]
        public string CategoryName { get; set; }

        [InverseProperty(nameof(Bicycle.Category))]
        public virtual ICollection<Bicycle> Bicycles { get; set; }
    }
}
