using koi_jabo.Models.GeoJson;
using koi_jabo.Models.OpenCloseTime;
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

        [Required(ErrorMessage = "Restaurant Area must be provided")]
        public string Area { get; set; }        

        [Required(ErrorMessage ="Restaurant address must be provided")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Restaurant GeoCoordinate must be provided")]
        public Point GeoPoint { get; set; }

        public List<OpenCloseTimeModel> TimeTable { get; set; }

        public double GeneralRatingRating { get; set; }
        public double AmbienceRating { get; set; }
        public double ServiceRating { get; set; }
        public double FoodRating { get; set; }

        [Required(ErrorMessage ="Costrating must be given")]
        public int CostRating { get; set; }

        public string PhoneNumber { get; set; }
        public string CostPerPerson { get; set; }

        [Required(ErrorMessage = "CostUpperLimit must be given")]
        public int CostUpperLimit { get; set; }

        [Required(ErrorMessage = "CostLowerLimit must be given")]
        public int CostLowerLimit { get; set; }
        
        public List<string> Tags { get; set; }        
        public List<string> Cuisines { get; set; }


    }
}