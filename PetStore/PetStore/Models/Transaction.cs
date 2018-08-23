using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    [Table("Transaction")]
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int CustomerID { get; set; }

        [Required]
        public List<Product> Products { get; set; }

        [Required]
        public decimal Total { get; set; }

        public bool Paid { get; set; }

    }
}