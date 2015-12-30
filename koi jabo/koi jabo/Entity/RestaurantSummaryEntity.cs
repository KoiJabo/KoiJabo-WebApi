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
        public List<string> Cuisines { get; set; }
        public double GeneralRatingRating { get; set; }
        public double AmbienceRating { get; set; }
        public double ServiceRating { get; set; }
        public double FoodRating { get; set; }
        public int CostRating { get; set; }

        public RestaurantSummaryEntity()
        {

        }

        public RestaurantSummaryEntity(RestaurantModel model)
        {
            this.Name = model.Name;
            this.Area = model.Area;
            this.Cuisines = model.Cuisines;
            this.GeneralRatingRating = model.GeneralRatingRating;
            this.AmbienceRating = model.AmbienceRating;
            this.ServiceRating = model.ServiceRating;
            this.FoodRating = model.FoodRating;
            this.CostRating = model.CostRating;
        }
    }
}
