using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BicyleStoreAPI.Models
{
    [Table("bicycles")]
    public partial class Bicycle
    {
        public Bicycle()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("product_id")]
        public int ProductId { get; set; }
        [Required]
        [Column("product_model")]
        [StringLength(100)]
        public string ProductModel { get; set; }
        [Column("production_year")]
        public int? ProductionYear { get; set; }
        [Column("gender")]
        [StringLength(10)]
        public string Gender { get; set; }
        [Column("price")]
        public int Price { get; set; }
        [Column("brand_id")]
        public int BrandId { get; set; }
        [Column("category_id")]
        public int CategoryId { get; set; }
       

        [ForeignKey(nameof(BrandId))]
        [InverseProperty("Bicycles")]
        public virtual Brand Brand { get; set; }
        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Bicycles")]
        public virtual Category Category { get; set; }
        [InverseProperty(nameof(Order.Product))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
