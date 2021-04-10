using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BicyleStoreAPI.Models
{
    [Table("orders")]
    public partial class Order
    {
        [Key]
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("product_id")]
        public int? ProductId { get; set; }
        [Column("customer_id")]
        public int? CustomerId { get; set; }
        [Column("order_date", TypeName = "date")]
        public DateTime? OrderDate { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("price")]
        public int Price { get; set; }
        [Column("cost")]
        public int? Cost { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(CustomerInfo.Orders))]
        public virtual CustomerInfo Customer { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Bicycle.Orders))]
        public virtual Bicycle Product { get; set; }
    }
}
