using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace koi_jabo.Models
{
    public class RestaurantModel
    {
        [Required(ErrorMessage = "Restaurant Name must be provided")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Restaurant address must be provided")]
        public string Address { get; set; }

    }
}