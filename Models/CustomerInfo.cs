using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BicyleStoreAPI.Models
{
    [Table("customer_info")]
    public partial class CustomerInfo
    {
        public CustomerInfo()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Required]
        [Column("first_name")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [Column("family_name")]
        [StringLength(100)]
        public string FamilyName { get; set; }
        [Column("city")]
        [StringLength(100)]
        public string City { get; set; }
        [Column("street_name")]
        [StringLength(250)]
        public string StreetName { get; set; }
        [Column("zip_code")]
        public int? ZipCode { get; set; }
        [Required]
        [Column("email")]
        [StringLength(250)]
        public string Email { get; set; }
        [Column("phone_number")]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [InverseProperty(nameof(Order.Customer))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
