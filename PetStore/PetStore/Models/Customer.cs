using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    // 20180824 we probably need a customer class? - kelsey
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }

        public int OrderId { get; set; }

        // a customer will have a list of orders
        public List<Order> Orders { get; set; }

        [Required(ErrorMessage = "Your phone number is required.")]
        [Display(Name = "Phone Number")]
        public string CustomerPhone { get; set; }

        [Required(ErrorMessage = "Your email address is required.")]
        [Display(Name = "Email Address")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Your payment method is required.")]
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "Your billing address is required.")]
        public int BillingAddressId { get; set; }

        [Required(ErrorMessage = "Your shipping address is required.")]
        public int ShippingAddressId { get; set; }

        public PaymentInformation PaymentInformation { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public ShippingAddress ShippingAddress { get; set; }

        public bool BillingAddressIsDifferent { get; set; }


    }
}
 