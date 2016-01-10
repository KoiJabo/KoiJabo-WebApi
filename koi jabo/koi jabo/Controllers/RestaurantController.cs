using koi_jabo.Entity;
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
using koi_jabo.Lib.Repository.Restaurant;
using System.Web.Http.Cors;
using koi_jabo.Lib.MongoContext;
using Newtonsoft.Json.Linq;

namespace koi_jabo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RestaurantController : ApiController
    {
        KoiJaboMongoDataContext context = new KoiJaboMongoDataContext();
        RestaurantRepository _repository;
        public RestaurantController()
        {
            _repository = new RestaurantRepository();
        }
        [HttpPost]
        public async Task<IHttpActionResult> Create(RestaurantModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await _repository.Create(model);
            return Json(entity);
        }

        [HttpPost]
        public async Task<IHttpActionResult> FormDataInput(List<RestaurantFormValue> value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var entity = await _repository.FormDataInput(value);
                return Json(true);
            }
            catch(Exception e)
            {
                return Json(false);
            }
            
        }

        [HttpGet]
        public async Task<IHttpActionResult> Search()
        {
            try
            {
                var list = await _repository.Search(Request);               
                return Json(list);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IHttpActionResult GetOptionsForDashBoard()
        {
            return Json(new OptionsForDashBoard());
        }
        [HttpGet]
        public async Task<IHttpActionResult> Get(string id=null)
        {            
            try
            {                
                var one = await _repository.Get(id);
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
                var updatedRestaurant = _repository.Update(restaurant);
                return Json(updatedRestaurant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> FormDataUpdate(List<RestaurantFormValue> value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatedRestaurant = await _repository.UpdateFormValue(value);
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
                var deleteRestaurant =_repository.Delete(id);                                
                return Json(deleteRestaurant);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
