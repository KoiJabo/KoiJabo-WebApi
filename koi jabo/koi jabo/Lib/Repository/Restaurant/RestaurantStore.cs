using koi_jabo.Lib.MongoContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using koi_jabo.Entity;
using koi_jabo.Models;
using MongoDB.Driver;
using System.Web.Http;
using koi_jabo.Lib.Helper;

namespace koi_jabo.Lib.Repository.Restaurant
{
    public class RestaurantStore
    {
        KoiJaboMongoDataContext context = new KoiJaboMongoDataContext();

        internal async Task<RestaurantEntity> Create(RestaurantEntity entity)
        {
            await context.Restaurants.InsertOneAsync(entity);
            return entity;

        }

        internal async Task<List<RestaurantSummaryEntity>> Search(FilterDefinition<RestaurantEntity> searchFilter, bool isOpenNow)
        {
            var Collection = context.Database.GetCollection<RestaurantEntity>(MongoCollectionNames.RestaurantsCollectionName);
            var searchResult = await Collection.Find(searchFilter).ToListAsync();
            var list = new List<RestaurantSummaryEntity>();
            foreach (var item in searchResult)
            {
                if (isOpenNow)
                {
                    item.IsOpenNow = OpenOrCloseDetector.Detect(item);
                }
                var result = new RestaurantSummaryEntity(item);
                list.Add(result);
            }
            return list;
        }

        public async Task<RestaurantEntity> Get(string id)
        {
            var _id = "{_id : ObjectId(\"" + id + "\")}";
            var one = await context.Restaurants.Find(x => x._id == id).SingleAsync();
            return one;
        }

        internal async Task<DeleteResult> Delete(FilterDefinition<RestaurantEntity> filter)
        {
            var deleteRestaurant = await context.Restaurants.DeleteOneAsync(filter);
            return deleteRestaurant;
        }

        public async Task<ReplaceOneResult> Update(RestaurantEntity restaurant)
        {
            var filter = Builders<RestaurantEntity>.Filter.Where(x => x._id == restaurant._id);
            var updatedRestaurant = await context.Restaurants.ReplaceOneAsync(filter, restaurant);
            return updatedRestaurant;
        }
    }
}
