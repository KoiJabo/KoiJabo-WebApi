using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using koi_jabo.Entity;
using koi_jabo.Lib.MongoContext;
using koi_jabo.Models;
using koi_jabo.Lib.Helper;
using MongoDB.Driver;

namespace koi_jabo.Lib.Repository.Restaurant
{
    public class RestaurantManager
    {
        RestaurantStore _store;
        public RestaurantManager()
        {
            _store = new RestaurantStore();
        }
        public async Task<RestaurantEntity> Create(RestaurantModel model)
        {
            RestaurantEntity entity = new RestaurantEntity(model);
            return await _store.Create(entity);
        }
        private FilterDefinition<RestaurantEntity> GetSearchFilter(HttpRequestMessage request)
        {
            var queryStringParameter = request.GetQueryNameValuePairs().ToDictionary(x => x.Key, y => y.Value);
            var searchFilter = SearchRestaurants.GetSearchFilter(queryStringParameter);
            return searchFilter;
        }
        public async Task<IEnumerable<RestaurantSummaryEntity>> Search(HttpRequestMessage request, int page, int pageSize)
        {
            var searchFilter = GetSearchFilter(request);
            KeyValuePair<string, string> pair = new KeyValuePair<string, string>("isopen", "true");                   
            return await _store.Search(searchFilter, page*pageSize, pageSize);
        }

        public async Task<long> CountToTal(HttpRequestMessage request)
        {
            var searchFilter = GetSearchFilter(request);
            return await _store.CountTotal(searchFilter);
        }

        public Task<DeleteResult> Delete(string id)
        {
            var filter = Builders<RestaurantEntity>.Filter.Where(x => x._id == id);
            return _store.Delete(filter);
        }

     

        internal async Task<ReplaceOneResult> Update(RestaurantEntity restaurant)
        {
            var id = restaurant._id;
            return await _store.Update(restaurant);            
        }

        public async Task<RestaurantEntity> Get(string id)
        {
            return await _store.Get(id);
        }
    }
}
