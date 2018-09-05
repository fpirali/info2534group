using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Models
{
    [Table("PaymentInformation")]
    public class PaymentInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "A payment method is required.")]
        [Display(Name = "Credit card number")]
        [DataType(DataType.CreditCard)]
        [StringLength(20, ErrorMessage = "Enter a 20-digit credit card number.")]
        public string CardNumber { get; set; }

        //[Required(ErrorMessage = "The month of expiration is required.")]
        [Display(Name = "Month")]
        public int ExpirationMonth { get; set; }

        //[Required(ErrorMessage = "The year of expiration is required.")]
        [Display(Name = "Year")]
        public int ExpirationYear { get; set; }

        [Required(ErrorMessage = "The credit card pin is required.")]
        [Display(Name = "Pin")]
        [StringLength(3, ErrorMessage = "Enter a 3-digit pin.")]
        public string CardPin { get; set; }

        //public int[] Months = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        //public int[] Years = { 2018, 2019, 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030,
        //    2031, 2032, 2033, 2034, 2035, 2036, 2037, 2038 };      
    }
}