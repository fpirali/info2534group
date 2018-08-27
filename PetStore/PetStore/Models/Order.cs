using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    // 20180824 do we need an order class to expand on transaction? - kelsey
    // also, would we need a separate class for order item (product id, quantity, price)??
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // this will correspond with the customer id
        public int CustomerId { get; set; }

        //// this will correspond with the transaction id??
        //public int TransactionId { get; set; }

        //public DateTime OrderDate { get; set; }

        //// list of order items??
        //public List<OrderItem> OrderItems { get; set; }

        //public decimal Total { get; set; }
    }
}