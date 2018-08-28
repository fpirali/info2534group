using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class Pet
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The pet type is required.")]
        [Display(Name = "Pet type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "The pet description is required.")]
        [Display(Name = "Pet description")]
        public string Description { get; set; }
    }
}