using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koi_jabo.Models
{
    public class ReviewModel
    {
        public int FoodRating { get; set; }
        public int ServiceRating { get; set; }
        public int AmbienceRating { get; set; }
        public int CleanlinesRating { get; set; }
        public int OverAllRating { get; set; }

        public string TextReview { get; set; }
        public string Tips { get; set; }
        public bool Verified { get; set; }

        [Required(ErrorMessage ="User _id must be provided")]
        public string FbUserId { get; set; }

        public string FbUserName { get; set; }
        [Required(ErrorMessage = "User _id must be provided")]
        public string RestaurantId { get; set; }

    }
}
