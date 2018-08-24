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

        // this will correspond with the transaction id
        public int TransactionId { get; set; }

        // a customer will have a list of orders
        public List<Order> Orders { get; set; }

        // this is all the customer contact information, address, etc
        [Required(ErrorMessage = "Your first name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Your last name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Your address is required.")]
        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Your city of residence is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Your state of residence is required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Your postal code is required.")]
        [Display(Name = "Zip Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Your phone number is required.")]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Your email address is required.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}