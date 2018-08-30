using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public string Name { get; set; }

        // 20180827 added error message and multi-line data type - kelsey
        [Required(ErrorMessage = "The description of the product is required.")]
        [DataType(DataType.MultilineText)]
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
        
        [Display(Name = "Is on sale", Description = "On sale")]
        public bool OnSale { get; set; }

        // 20180828 added markdown field to model - kelsey
        [Display(Name = "Percent markdown")]
        public decimal Markdown { get; set; }

        public Category Category { get; set; }

        // 20180828 added field for pet type id 
        //[Required(ErrorMessage = "The type of pet this is intended for is required.")]
        [Display(Name = "Type of pet")]
        public int PetId { get; set; }
        public Pet Pet { get; set; }

        // 20180829 this will hold all drop down list items for these properties
        public IEnumerable<SelectListItem> Categories { get; set; }

        public IEnumerable<SelectListItem> Pets { get; set; }
    }
}