using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    [Table("PaymentInformation")]
    public class PaymentInformation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

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
    }
}