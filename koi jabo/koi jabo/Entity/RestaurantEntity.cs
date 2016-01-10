using koi_jabo.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koi_jabo.Entity
{
    public class RestaurantEntity : RestaurantModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonIgnore]
        public bool IsOpenNow { get; set; }
        [BsonIgnore]
        public double Distance { get; set; }
        [BsonIgnore]
        public string CostPerPerson { get; set; }
        public int CostRating { get; set; }
        public RestaurantEntity()
        {

        }
        public RestaurantEntity(RestaurantModel model)
        {
            this.Name = model.Name;
            this.Address = model.Address;
            this.Area = model.Area;
            this.TitleImageUrl = model.TitleImageUrl;
            this.TimeTable = model.TimeTable;
            this.GeoPoint = model.GeoPoint;
            this.GeneralRatingRating = model.GeneralRatingRating;
            this.AmbienceRating = model.AmbienceRating;
            this.ServiceRating = model.ServiceRating;
            this.FoodRating = model.FoodRating;
            this.PhoneNumber = model.PhoneNumber;

            this.CostPerPerson = model.CostLowerLimit.ToString() + " - " + model.CostUpperLimit.ToString() + " taka"; ;
            this.CostUpperLimit = model.CostUpperLimit;
            this.CostLowerLimit = model.CostLowerLimit;

            this.CreditCards = model.CreditCards;
            this.GoodFor = model.GoodFor;
            this.Cuisines = model.Cuisines;
            this.EstablishmentType = model.EstablishmentType;

            this.Parking = model.Parking;
            this.Attire = model.Attire;
            this.NoiseLevel = model.NoiseLevel;

            this.Rooftop = model.Rooftop;
            this.Reservation = model.Reservation;
            this.Delivery = model.Delivery;
            this.TakeOut = model.TakeOut;
            this.OutDoor = model.OutDoor;
            this.Wifi = model.Wifi;
            this.Tv = model.Tv;
            this.CandleLight = model.CandleLight;
            this.LuxuryDining = model.LuxuryDining;
            this.Washroom = model.Washroom;
            this.Toilet = model.Toilet;
        }
    }
}
