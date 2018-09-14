using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    [Table("BillingAddresses")]
    public class BillingAddress
    {
        /************************************
         * this is the customer's billing information *
        ************************************/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Your address is required.")]
        [Display(Name = "Address Line 1")]
        public string BillingAddress1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string BillingAddress2 { get; set; }

        [Required(ErrorMessage = "Your city of residence is required.")]
        [Display(Name = "City")]
        public string BillingCity { get; set; }

        [Required(ErrorMessage = "Your state of residence is required.")]
        [Display(Name = "State")]
        public string BillingState { get; set; }

        [Required(ErrorMessage = "Your postal code is required.")]
        [Display(Name = "Zip Code")]
        public string BillingPostalCode { get; set; }
    }
}