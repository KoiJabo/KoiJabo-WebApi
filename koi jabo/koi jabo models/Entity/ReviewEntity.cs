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
    public class ReviewEntity : ReviewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public ReviewEntity()
        {

        }
        public ReviewEntity(ReviewModel model)
        {
            this.FoodRating = model.FoodRating;
            this.ServiceRating = model.ServiceRating;
            this.AmbienceRating = model.AmbienceRating;
            this.OverAllRating = model.OverAllRating;
            this.TextReview = model.TextReview;
            this.Tips = model.Tips;
            this.Verified = model.Verified;
            this.UserId = model.UserId;
            this.RestaurantId = model.RestaurantId;
        }
    }
}
