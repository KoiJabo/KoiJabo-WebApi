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
    public class RestaurantSummaryEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonIgnore]
        public bool IsOpenNow { get; set; }
        [BsonIgnore]
        public double Distance { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public string TitleImageUrl { get; set; }
        public List<string> Cuisines { get; set; }
        public double GeneralRatingRating { get; set; }
        public double AmbienceRating { get; set; }
        public double ServiceRating { get; set; }
        public double FoodRating { get; set; }
        public int CostRating { get; set; }

        public RestaurantSummaryEntity()
        {

        }

        public RestaurantSummaryEntity(RestaurantEntity entity)
        {
            this._id = entity._id;
            this.Name = entity.Name;
            this.Area = entity.Area;
            this.TitleImageUrl = entity.TitleImageUrl;
            this.IsOpenNow = entity.IsOpenNow;
            this.Cuisines = entity.Cuisines;
            this.GeneralRatingRating = entity.GeneralRatingRating;
            this.AmbienceRating = entity.AmbienceRating;
            this.ServiceRating = entity.ServiceRating;
            this.FoodRating = entity.FoodRating;
            this.CostRating = entity.CostRating;
        }
    }
}
