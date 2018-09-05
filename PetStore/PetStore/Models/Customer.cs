using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        // these are the foreign key relationships
        public string UserId { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("ShippingAddress")]
        [Required(ErrorMessage = "Your shipping address is required.")]
        public int ShippingAddressId { get; set; }

        [ForeignKey("PaymentInformation")]
        [Required(ErrorMessage = "Your payment method is required.")]
        public int PaymentInformationId { get; set; }

        [ForeignKey("BillingAddress")]
        [Required(ErrorMessage = "Your billing address is required.")]
        public int BillingAddressId { get; set; }


        // this is the customer's general information
        [Required(ErrorMessage = "Your first name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your last name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Your phone number is required.")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Your email address is required.")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        public bool BillingAddressIsDifferent { get; set; }

        public List<Order> Orders { get; set; }


        // these are the foreign object references
        public PaymentInformation PaymentInformation { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public ShippingAddress ShippingAddress { get; set; }        


    }
}
 