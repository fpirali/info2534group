using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class Cart
    {
        public ApplicationUser UserId { get; set; }
        public List<ProductModels> Products { get; set; }
        public bool IsPaid { get; set; }
    }
}