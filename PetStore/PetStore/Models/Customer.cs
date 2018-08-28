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

        // this will correspond with the AspNetUsers id?
        public int UserId { get; set; }

        // this will correspond with the order idd
        public int OrderId { get; set; }

        // a customer will have a list of orders
        public List<Order> Orders { get; set; }

        [Required(ErrorMessage = "Your phone number is required.")]
        [Display(Name = "Phone Number")]
        public string CustomerPhone { get; set; }

        [Required(ErrorMessage = "Your email address is required.")]
        [Display(Name = "Email Address")]
        public string CustomerEmail { get; set; }

        /************************************
         * this is the customer's shipping information *
        ************************************/
        [Required(ErrorMessage = "Your first name is required.")]
        [Display(Name = "First Name")]
        public string ShippingFirstName { get; set; }

        [Required(ErrorMessage = "Your last name is required.")]
        [Display(Name = "Last Name")]
        public string ShippingLastName { get; set; }

        [Required(ErrorMessage = "Your address is required.")]
        [Display(Name = "Address Line 1")]
        public string ShippingAddress1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string ShippingAddress2 { get; set; }

        [Required(ErrorMessage = "Your city of residence is required.")]
        public string ShippingCity { get; set; }

        [Required(ErrorMessage = "Your state of residence is required.")]
        public string ShippingState { get; set; }

        [Required(ErrorMessage = "Your postal code is required.")]
        [Display(Name = "Zip Code")]
        public string ShippingPostalCode { get; set; }

        /************************************
         * this is the customer's billing information *
        ************************************/
        [Required(ErrorMessage = "A payment method is required.")]
        [Display(Name = "Credit card number")]
        [DataType(DataType.CreditCard)]
        [StringLength(20, ErrorMessage = "Enter a 20-digit credit card number.")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "The month of expiration is required.")]
        [Display(Name = "Month")]
        [DataType(DataType.Date)]
        [StringLength(2, ErrorMessage = "Enter a 2-digit month.")]
        public string ExpirationMonth { get; set; }

        [Required(ErrorMessage = "The year of expiration is required.")]
        [Display(Name = "Year")]
        [DataType(DataType.Date)]
        [StringLength(4, ErrorMessage = "Enter a 4-digit year.")]
        public string ExpirationYear { get; set; }

        [Required(ErrorMessage = "The credit card pin is required.")]
        [Display(Name = "Pin")]
        [StringLength(3, ErrorMessage = "Enter a 3-digit pin.")]
        public string CardPin { get; set; }

        [Required(ErrorMessage = "Your first name is required.")]
        [Display(Name = "First Name")]
        public string BillingFirstName { get; set; }

        [Required(ErrorMessage = "Your last name is required.")]
        [Display(Name = "Last Name")]
        public string BillingLastName { get; set; }

        [Required(ErrorMessage = "Your address is required.")]
        [Display(Name = "Address Line 1")]
        public string BillingAddress1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string BillingAddress2 { get; set; }

        [Required(ErrorMessage = "Your city of residence is required.")]
        public string BillingCity { get; set; }

        [Required(ErrorMessage = "Your state of residence is required.")]
        public string BillingState { get; set; }

        [Required(ErrorMessage = "Your postal code is required.")]
        [Display(Name = "Zip Code")]
        public string BillingPostalCode { get; set; }
    }
}
 