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
using koi_jabo_models.Models.Pagination;

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

        public async Task<PageEnvelope<RestaurantSummaryEntity>> Search(HttpRequestMessage request, int page, int pageSize)
        {
            var searchResult = await _manager.Search(request, page, pageSize);
            var total = await _manager.CountToTal(request);
            var queryStringParameter = request.GetQueryNameValuePairs().ToDictionary(x => x.Key, y =>(object) y.Value);
            string Type = "Type";
            return new PageEnvelope<RestaurantSummaryEntity>(total, page, pageSize, "DefaultApi", searchResult, request, queryStringParameter);
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
            var entity = form.ParseFormValueToModel(value);            
            return await _manager.Create(entity);
           
        }

        internal async Task<ReplaceOneResult> UpdateFormValue(List<RestaurantFormValue> value)
        {
            var form = new RestaurantFormValue();
            var entity = form.ParseFormValueToModel(value);
            return await _manager.Update(entity);
        }
    }
}
