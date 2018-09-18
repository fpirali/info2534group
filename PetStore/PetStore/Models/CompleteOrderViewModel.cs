using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetStore.Models
{
    public class CompleteOrderViewModel
    {
        public Cart Cart { get; set; }

        public CompleteOrderViewModel()
        {
            Cart = new Models.Cart();
        }
    }
}