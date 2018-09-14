using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    [Table("ShippingAddresses")]
    public class ShippingAddress
    {
        /************************************
         * this is the customer's shipping information *
        ************************************/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Your address is required.")]
        [Display(Name = "Address Line 1")]
        public string ShippingAddress1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string ShippingAddress2 { get; set; }

        [Required(ErrorMessage = "Your city of residence is required.")]
        [Display(Name = "City")]
        public string ShippingCity { get; set; }

        [Required(ErrorMessage = "Your state of residence is required.")]
        [Display(Name = "State")]
        public string ShippingState { get; set; }

        [Required(ErrorMessage = "Your postal code is required.")]
        [Display(Name = "Zip Code")]
        public string ShippingPostalCode { get; set; }
    }
}