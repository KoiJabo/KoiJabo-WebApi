using koi_jabo.Entity;
using koi_jabo.Lib.DBConnection;
using koi_jabo.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Http;
using MongoDB.Bson.Serialization;
using koi_jabo.Lib.Helper;

namespace koi_jabo.Controllers
{
    public class RestaurantController : ApiController
    {
        KoiJaboMongoDataContext context = new KoiJaboMongoDataContext();

        [HttpPost]
        public async Task<IHttpActionResult> Create(RestaurantModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await context.Restaurants.InsertOneAsync(new RestaurantEntity(model));
            return Json(model);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Search(SearchParams options)
        {
            var Collection = context.Database.GetCollection<BsonDocument>("Restaurants");
            var req = Request.GetQueryNameValuePairs();
            var queryString = SearchParams.GetSearchFilter(req);
            var searchResult = Collection.Find(queryString).ToListAsync();
            var result = BsonSerializer.Deserialize<RestaurantEntity>(searchResult.Result[0]);
            return Json(result);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string id=null, int start=-1, int limit=-1)
        {
            
            try
            {
                if (id != null)
                {
                    //var filter = Builders<RestaurantEntity>.Filter.Where(x => x._id == id);
                    //var one = await context.Restaurants.Find(filter).FirstOrDefaultAsync();
                    var _id = ObjectId.Parse("5681f4f2cb71ac1598308f93");

                    var FilterQuery = Builders<BsonDocument>.Filter;
                    var ProjectQuery = Builders<BsonDocument>.Projection;
                    var Collection = context.Database.GetCollection<BsonDocument>("Restaurants");

                    var filter = FilterQuery.Eq("TakeReservations", true) & FilterQuery.Eq("Delivery", false);
                    var project = ProjectQuery.Exclude("");

                    //var one = Collection.Find(filter).Project(project).ToListAsync();
                    FilterDefinition<BsonDocument> searchFilter = "{'TakeReservations': true}";
                    var one = Collection.Find(searchFilter).ToListAsync();
                    //var result = BsonSerializer.Deserialize<RestaurantEntity>(one.Result[0]);
                    var result = BsonSerializer.Deserialize<RestaurantEntity>(one.Result[0]);

                    return Json(result);
                }
                else if (start != -1 && limit != -1)
                {
                    var filter = new BsonDocument();
                    var allInTheRange = await context.Restaurants.Find(filter).Skip(start).Limit(limit).ToListAsync();
                    return Json(allInTheRange);
                }
                else
                {
                    var filter = new BsonDocument();
                    var all = await context.Restaurants.Find(filter: filter).ToListAsync();
                    var json = Json(all);
                    return Json(all);
                }

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(RestaurantEntity restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var filter = Builders<RestaurantEntity>.Filter.Where(x => x._id == restaurant._id);
            var updatedRestaurant = await context.Restaurants.ReplaceOneAsync(filter, restaurant);
            return Json(updatedRestaurant);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest("Id can not be null");            
            }

            try
            {
                var filter = Builders<RestaurantEntity>.Filter.Where(x => x._id == id);
                var deleteRestaurant = await context.Restaurants.DeleteOneAsync(filter);
                return Json(deleteRestaurant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
