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

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        // 20180824 added category id and price to model - kelsey
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public decimal Price { get; set; }

        // 2018/0827 added image file path and on sale flag to model - kelsey
        [Required]
        [Display(Name = "The image file path for the product.")]
        public string ImageFilePath { get; set; }

        [Required]
        [Display(Name = "Is the product currently on sale?")]
        public bool OnSale { get; set; }
    }
}