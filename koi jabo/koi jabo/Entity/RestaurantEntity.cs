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
        public RestaurantEntity()
        {

        }
        public RestaurantEntity(RestaurantModel model)
        {
            this.Name = model.Name;
            this.Address = model.Address;
            this.Area = model.Area;
            this.TimeTable = model.TimeTable;
            this.GeoPoint = model.GeoPoint;
            this.GeneralRatingRating = model.GeneralRatingRating;
            this.AmbienceRating = model.AmbienceRating;
            this.ServiceRating = model.ServiceRating;
            this.FoodRating = model.FoodRating;
            this.CostRating = model.CostRating;
            this.PhoneNumber = model.PhoneNumber;
            this.CostPerPerson = model.CostPerPerson;
            this.CostUpperLimit = model.CostUpperLimit;
            
            //this.TakeReservations = model.TakeReservations;
            //this.Delivery = model.Delivery;
            //this.OutdoorSeating = model.OutdoorSeating;
            //this.Casual = model.Casual;
            //this.Gossip = model.Gossip;
            //this.Hangout = model.Hangout;
            //this.Meetings = model.Meetings;
            //this.Visa = model.Visa;
            //this.Master = model.Master;
            //this.Nexus = model.Nexus;
            //this.AmericanExpress = model.AmericanExpress;
            //this.Parking = model.Parking;
            //this.Ac = model.Ac;
            this.Tags = model.Tags;
            this.Cuisines = model.Cuisines;
        }
    }
}
