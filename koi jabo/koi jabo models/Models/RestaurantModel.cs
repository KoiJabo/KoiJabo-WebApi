using koi_jabo.Models.GeoJson;
using koi_jabo.Models.OpenCloseTime;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        public string TitleImageUrl { get; set; }
        public string Parking { get; set; }

        public string Attire { get; set; }
        public string NoiseLevel { get; set; }
        public List<OpenCloseTimeModel> TimeTable { get; set; }

        public double GeneralRatingRating { get; set; }
        public double AmbienceRating { get; set; }
        public double ServiceRating { get; set; }
        public double FoodRating { get; set; }


        public string PhoneNumber { get; set; }
        

        [Required(ErrorMessage = "CostUpperLimit must be given")]
        public int CostUpperLimit { get; set; }

        [Required(ErrorMessage = "CostLowerLimit must be given")]
        public int CostLowerLimit { get; set; }


        public List<string> CreditCards { get; set; }
        public List<string> GoodFor { get; set; }
        public List<string> Cuisines { get; set; }
        public List<string> EstablishmentType { get; set; }


     

        public List<string> TagsTrue { get; set; }
        public List<string> TagsFalse { get; set; }




    }
}