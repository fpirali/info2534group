using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class Question
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Your name is required.")]
        [Display(Name = "Your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Your email address is required.")]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The subject line is required.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "The message body is required.")]
        [Display(Name = "Type your question in the text box.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }


    }
}