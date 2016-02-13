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

        public async Task<IEnumerable<RestaurantSummaryEntity>> Search(HttpRequestMessage request, int page, int pageSize)
        {
            var queryStringParameter = request.GetQueryNameValuePairs().ToDictionary(x => x.Key, y => y.Value);
            var searchFilter = SearchRestaurants.GetSearchFilter(queryStringParameter);

            KeyValuePair<string, string> pair = new KeyValuePair<string, string>("isopen", "true");
            bool isOpenNow = queryStringParameter.Contains(pair);

            
            return await _store.Search(searchFilter, isOpenNow, page*pageSize, pageSize);
        }

        public async Task<long> CountToTal()
        {
            return await _store.CountTotal();
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
