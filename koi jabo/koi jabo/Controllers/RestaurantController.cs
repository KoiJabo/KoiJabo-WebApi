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
using System.Threading.Tasks;
using System.Web.Http;

namespace koi_jabo.Controllers
{
    public class RestaurantController : ApiController
    {
        KoiJaboMongoDataContext context = new KoiJaboMongoDataContext();
        public async Task<IHttpActionResult> Create(RestaurantModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await context.Restaurants.InsertOneAsync(new RestaurantEntity(model));
            return Json(model);
        }

        //public async Task<IEnumerable<TrackerInfo>> Find(bool isAssigned, int skip, int limit)
        //{
        //    return await this._context.Trackers.Find(x => x.IsAssigned == isAssigned).Skip(skip).Limit(limit).ToListAsync();
        //}
        public async Task<IHttpActionResult> Getall()
        {
            var filter = new BsonDocument();
            var all = await context.Restaurants.Find(filter: filter).ToListAsync();
            return Json(all);
        }
    }
}
