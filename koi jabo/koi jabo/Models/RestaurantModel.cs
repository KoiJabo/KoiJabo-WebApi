using koi_jabo.Models.GeoJson;
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

        [Required(ErrorMessage = "Restaurant Cuisine must be provided")]
        public List<string> Cuisines { get; set; }

        [Required(ErrorMessage ="Restaurant address must be provided")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Restaurant GeoCoordinate must be provided")]
        public Point GeoPoint { get; set; }

        public List<DayOfWeek> TimeTable { get; set; }

        public double GeneralRatingRating { get; set; }
        public double AmbienceRating { get; set; }
        public double ServiceRating { get; set; }
        public double FoodRating { get; set; }
        public int CostRating { get; set; }
        public string PhoneNumber { get; set; }
        public string CostPerPerson { get; set; }
        public int CostUpperLimit { get; set; }
        public bool TakeReservations { get; set; }
        public bool Delivery { get; set; }
        public bool OutdoorSeating { get; set; }
        public bool Casual { get; set; }
        public bool Gossip { get; set; }
        public bool Hangout { get; set; }
        public bool Meetings { get; set; }
        public bool Visa { get; set; }
        public bool Master { get; set; }
        public bool Nexus { get; set; }
        public bool AmericanExpress { get; set; }
        public bool Parking { get; set; }
        public bool Ac { get; set; }

        public List<string> Tags { get; set; }



    }
}