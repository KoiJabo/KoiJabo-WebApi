using koi_jabo.Entity;
using koi_jabo.Lib.DBConnection;
using koi_jabo.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace koi_jabo.Controllers
{
    class UserController : ApiController
    {
        KoiJaboMongoDataContext context = new KoiJaboMongoDataContext();
        [HttpPost]
        public async Task<IHttpActionResult> Create(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await context.Users.InsertOneAsync(new UserEntity(model));
            return Json(model);
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
