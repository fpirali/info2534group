using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        // 20180827 added display description and error message - kelsey
        [Required(ErrorMessage = "The name of the category is required.")]
        [Display(Description = "Category")]
        public string Name { get; set; }

        // 20180827 added required error message and multi line data type - kelsey
        [Required(ErrorMessage = "The description of the category is required.")]
        [DataType(DataType.MultilineText)]
        [MaxLength(500, ErrorMessage = "Description must be 500 characters or less.")]
        public string Description { get; set; }
    }
}