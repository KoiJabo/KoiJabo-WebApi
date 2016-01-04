﻿using koi_jabo.Models;
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
            this.CostLevel = model.CostLevel;
            this.PhoneNumber = model.PhoneNumber;
            this.CostPerPerson = model.CostLowerLimit.ToString() + " - " + model.CostUpperLimit.ToString() + " taka"; ;
            this.CostUpperLimit = model.CostUpperLimit;

            this.CreditCards = model.CreditCards;
            this.GoodFor = model.GoodFor;
            this.Parking = model.Parking;
            this.Attire = model.Attire;

            this.Rooftop = model.Rooftop;
            this.Reservation = model.Reservation;
            this.Delivery = model.Delivery;
            this.OutDoor = model.OutDoor;
            this.Wifi = model.Wifi;
            this.Tv = model.Tv;
            this.CandleLight = model.CandleLight;
            this.LuxuryDining = model.LuxuryDining;                      
            this.Cuisines = model.Cuisines;
        }
    }
}
