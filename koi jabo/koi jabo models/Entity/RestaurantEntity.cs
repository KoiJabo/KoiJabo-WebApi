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

            this.CostPerPerson = model.CostLowerLimit.ToString() + " - " + model.CostUpperLimit.ToString() + " taka";
            this.CostUpperLimit = model.CostUpperLimit;
            this.CostLowerLimit = model.CostLowerLimit;

            this.CreditCards = model.CreditCards;
            this.GoodFor = model.GoodFor;
            this.Cuisines = model.Cuisines;
            this.EstablishmentType = model.EstablishmentType;

            this.Parking = model.Parking;
            this.Attire = model.Attire;
            this.NoiseLevel = model.NoiseLevel;

            this.TagsFalse = model.TagsFalse;
            this.TagsTrue = model.TagsTrue;


            this.PopulateSearchTag(model);        
        }
        public void PopulateSearchTag(RestaurantModel model)
        {
            this.SearchTags = new List<string>();

            if (model.Name!=null)
            {
                this.SearchTags.Add(model.Name.ToLower());
            }

            if (model.Area!= null)
            {
                this.SearchTags.Add(model.Area.ToLower());
            }

            if (model.PhoneNumber!=null)
            {
                this.SearchTags.Add(model.PhoneNumber.ToLower());
            }

            if (model.Parking!=null)
            {
                this.SearchTags.Add(model.Parking.ToLower());
            }

            if (model.NoiseLevel!=null)
            {
                this.SearchTags.Add(model.NoiseLevel.ToLower());
            }
            if (model.Attire!= null)
            {
                this.SearchTags.Add(model.Attire.ToLower());
            }
            

            foreach (var item in model.Cuisines)
            {
                if (item!=null)
                {

                }
                this.SearchTags.Add(item.ToLower());
            }
            foreach (var item in model.GoodFor)
            {
                if (item != null)
                {
                    this.SearchTags.Add(item.ToLower());
                }
                
            }
            foreach (var item in model.EstablishmentType)
            {
                if (item != null)
                {
                    this.SearchTags.Add(item.ToLower());
                }
                
            }
            foreach (var item in model.TagsTrue)
            {
                if (item != null)
                {
                    this.SearchTags.Add(item.ToLower());
                }
                
            }
            foreach (var item in model.CreditCards)
            {
                if (item != null)
                {
                    this.SearchTags.Add(item.ToLower());
                }
            }
        }
    }
}
