using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    [Table("Product")]
    public class ProductModels
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        // 20180827 added error message - kelsey
        [Required(ErrorMessage = "The name of the product is required.")]
        [MaxLength(255)]
        public string Name { get; set; }

        // 20180827 added error message and multi-line data type - kelsey
        [Required(ErrorMessage = "The description of the product is required.")]
        [DataType(DataType.MultilineText)]
        [MaxLength(255)]
        public string Description { get; set; }

        // 20180824 added category id and price to model - kelsey
        [Required(ErrorMessage = "The categorization of the product is required.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The price of the product is required.")]
        [DataType(DataType.Currency, ErrorMessage = "The price must be a decimal!")]
        public decimal Price { get; set; }

        // 20180827 added image file path and on sale flag to model - kelsey
        [Required(ErrorMessage = "An image of the product is required.")]
        [Display(Name = "Image url")]
        public string ImageFilePath { get; set; }

        [Required(ErrorMessage = "You need to check one of the options.")]
        [Display(Name = "Is on sale", Description = "Is the product currently on sale?")]
        public bool OnSale { get; set; }

        public Category Category { get; set; }
    }
}