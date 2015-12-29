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
        public ObjectId _id { get; set; }
        public RestaurantEntity(RestaurantModel model)
        {
            this.Name = model.Name;
            this.Address = model.Address;
        }
    }
}
