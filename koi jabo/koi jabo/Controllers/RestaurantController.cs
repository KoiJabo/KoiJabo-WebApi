﻿using koi_jabo.Entity;
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
        public async Task<IHttpActionResult> Get(string id, int start=0, int limit=25)
        {
            try
            {
                if (id != null)
                {
                    var filter = Builders<RestaurantEntity>.Filter.Where(x => x._id == id);
                    var one = await context.Restaurants.Find(filter).FirstOrDefaultAsync();
                    return Json(one);
                }
                else if (start != null && limit != null)
                {
                    var filter = new BsonDocument();
                    var allInTheRange = await context.Restaurants.Find(filter).Skip(start).Limit(limit).ToListAsync();
                    return Json(allInTheRange);
                }
                else
                {
                    var filter = new BsonDocument();
                    var all = await context.Restaurants.Find(filter: filter).ToListAsync();
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
