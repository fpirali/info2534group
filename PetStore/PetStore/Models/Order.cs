using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        // 20180827 added order date, order items, total, and is paid for flag - kelsey
        public DateTime OrderDate { get; set; }

        // one record per item, so if two items are ordered there will be two records for the product
        public List<ProductModels> OrderItems { get; set; }

        public decimal ItemPrice { get; set; }

        // the total for the order, which is the sum of all products in the list
        public decimal OrderTotal { get; set; }
    }
}