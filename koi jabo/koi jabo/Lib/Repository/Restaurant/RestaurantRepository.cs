using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using koi_jabo.Models;
using koi_jabo.Entity;
using System.Web.Http;
using System.Net.Http;
using MongoDB.Driver;

namespace koi_jabo.Lib.Repository.Restaurant
{
    public class RestaurantRepository
    {
        RestaurantManager _manager;
        public RestaurantRepository()
        {
            _manager = new RestaurantManager();
        }
        public async Task<RestaurantEntity> Create(RestaurantModel model)
        {
            return await _manager.Create(model);
        }

        public async Task<List<RestaurantSummaryEntity>> Search(HttpRequestMessage request)
        {
            return await _manager.Search(request);
        }

        public Task<RestaurantEntity> Get(string id)
        {
            return _manager.Get(id);
        }

        public async Task<ReplaceOneResult> Update(RestaurantEntity restaurant)
        {
            return await _manager.Update(restaurant);
        }

        public Task<DeleteResult> Delete(string id)
        {
            return _manager.Delete(id);
        }

        public async Task<RestaurantEntity> FormDataInput(List<RestaurantFormValue> value)
        {
            var form = new RestaurantFormValue();
            var model = form.ParseFormValueToModel(value);
            var entity = new RestaurantEntity(model);
            return await _manager.Create(entity);
           
        }
    }
}
