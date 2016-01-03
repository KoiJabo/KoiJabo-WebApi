using koi_jabo.Entity;
using koi_jabo.Lib.DBConnection;
using koi_jabo.Models;
using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MongoDB.Bson;
using System.Web.Http.Cors;

namespace koi_jabo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReviewController : ApiController
    {
        KoiJaboMongoDataContext context = new KoiJaboMongoDataContext();
        

        [HttpPost]
        public async Task<IHttpActionResult> Create(ReviewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await context.Reviews.InsertOneAsync(new ReviewEntity(model));
            return Json(model);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string id = null)
        {
            try
            {
                var _id = "{_id : ObjectId(\"" + id + "\")}";
                var one = await context.Reviews.Find(x => x._id == id).SingleAsync();
                return Json(one);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetReviews(string restaurantId = null, bool verfied = false, bool allreview=false)
        {

            try
            {
                var filter = Builders<ReviewEntity>.Filter; 
                var searchFilter = filter.Where(x=> x.RestaurantId == restaurantId);
                if (verfied) searchFilter &= filter.Where(x => x.Verified == true);
                else if (allreview) searchFilter &= new BsonDocument();

                var all = await context.Reviews.Find(searchFilter).ToListAsync();
                return Json(all);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IHttpActionResult> Update(ReviewEntity review)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var filter = Builders<ReviewEntity>.Filter.Where(x => x._id == review._id);
                var updateuser = await context.Reviews.ReplaceOneAsync(filter, review);
                return Json(updateuser);
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
                var filter = Builders<ReviewEntity>.Filter.Where(x => x._id == id);
                var deleteReview = await context.Reviews.DeleteOneAsync(filter);
                return Json(deleteReview);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}