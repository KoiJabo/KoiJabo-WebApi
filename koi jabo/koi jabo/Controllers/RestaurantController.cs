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
            model.CostPerPerson = model.CostLowerLimit.ToString() + " - " + model.CostUpperLimit.ToString() + " taka";
            await context.Restaurants.InsertOneAsync(new RestaurantEntity(model));
            return Json(model);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Search()
        {
            var Collection = context.Database.GetCollection<RestaurantEntity>("Restaurants");
            var queryStringParameter = Request.GetQueryNameValuePairs().ToDictionary(x=> x.Key, y=>y.Value);
            var searchFilter = SearchRestaurants.GetSearchFilter(queryStringParameter);
            try
            {
                var searchResult = await Collection.Find(searchFilter).ToListAsync();
                var list = new List<RestaurantSummaryEntity>();
                foreach (var item in searchResult)
                {
                    // NEED TO FIX THIS
                    KeyValuePair<string, string> pair = new KeyValuePair<string, string>("IsOpenNow", "true");
                    bool isOpenNow = queryStringParameter.Contains(pair);
                    if (isOpenNow) item.IsOpenNow = OpenOrCloseDetector.Detect(item);
                    // NEED TO FIX THIS


                    var result = new RestaurantSummaryEntity(item);
                    list.Add(result);

                }
                return Json(list);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string id=null)
        {            
            try
            {
                
                var _id = "{_id : ObjectId(\"" + id + "\")}";
                
                var one = await context.Restaurants.Find(x=>x._id == id).SingleAsync();
                return Json(one);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(RestaurantEntity restaurant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var filter = Builders<RestaurantEntity>.Filter.Where(x => x._id == restaurant._id);
                var updatedRestaurant = await context.Restaurants.ReplaceOneAsync(filter, restaurant);
                return Json(updatedRestaurant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
