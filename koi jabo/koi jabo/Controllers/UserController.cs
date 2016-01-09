using koi_jabo.Entity;
using koi_jabo.Lib.MongoContext;
using koi_jabo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace koi_jabo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        KoiJaboMongoDataContext context = new KoiJaboMongoDataContext();
        [HttpPost]
        public async Task<IHttpActionResult> Create(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                UserEntity entity = new UserEntity(model);
                await context.Users.InsertOneAsync(entity);
                return Json(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(string id = null)
        {
            try
            {
                var _id = "{_id : ObjectId(\"" + id + "\")}";
                var one = await context.Users.Find(x => x._id == id).SingleAsync();
                return Json(one);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var filter = Builders<UserEntity>.Filter.Where(x => x._id == user._id);
                var updateuser = await context.Users.ReplaceOneAsync(filter, user);
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
                var filter = Builders<UserEntity>.Filter.Where(x => x._id == id);
                var deleteUser = await context.Users.DeleteOneAsync(filter);
                return Json(deleteUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
