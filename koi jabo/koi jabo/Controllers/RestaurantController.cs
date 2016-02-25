using koi_jabo.Entity;
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
using MongoDB.Bson.Serialization;
using koi_jabo.Lib.Helper;
using koi_jabo.Lib.Repository.Restaurant;
using System.Web.Http.Cors;
using koi_jabo.Lib.MongoContext;
 

namespace koi_jabo.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RestaurantController : ApiController
    {
        
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
        /// <summary>
        /// This is the search action
        /// </summary>
        /// <param name="page">page number</param>
        /// <param name="pageSize">number of entrie per page</param>
        /// <param name="value"></param>
        /// <param name="isopen">you want currently open restaurants? true or false</param>
        /// <param name ="costupperlimit">upper limit of costs, int number</param>
        /// <param name="costlowerlimit">lower limit of costs, int number</param>
        /// <param name ="lat">your latitude</param>
        /// <param name="lon">your longitude</param>
        /// <param name ="distance">distance in meter</param>
        /// <returns>List of RestaurantSummary</returns>
        [HttpGet]
        public async Task<IHttpActionResult> Search(int page=0, int pageSize = 100)
        {
            try
            {
                if (pageSize == 0)
                    return BadRequest("Page size cant be 0");
                if (page < 0)
                    return BadRequest("Page index less than 0 provided");

                var list = await _repository.Search(Request, page, pageSize);
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
