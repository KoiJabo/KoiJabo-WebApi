using koi_jabo.Entity;
using koi_jabo.Models;
using koi_jabo.Models.GeoJson;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koi_jabo.Lib.Helper
{
    public static class SearchRestaurants
    {        
        public static FilterDefinition<RestaurantEntity> GetSearchFilter(IEnumerable<KeyValuePair<string, string>> QueryParameters)
        {
            FilterDefinition<RestaurantEntity> searchFilter;

            // NEED TO FIX THIS, TO DETERMINE THAT THE QUERYSTRINGPARAMTER DOESN'T CONTAIN ANY PARAM
            var idea = QueryParameters.ToString();
            if (idea == "System.Collections.Generic.KeyValuePair`2[System.String,System.String][]")
            {
                BsonDocument nofilter = new BsonDocument();
                return nofilter;
            }
           
            searchFilter = Builders<RestaurantEntity>.Filter.Where(x => x.Name != null);
            var filter = Builders<RestaurantEntity>.Filter;
            var tagsParams = new List<string>();
            var cuisineParams = new List<string>();
            foreach (var param in QueryParameters)
            {
                if (param.Key == "Name")
                {
                    searchFilter &= filter.Where(x => x.Name.Contains(param.Value));
                }
                else if (param.Key == "Area")
                {
                    searchFilter &= filter.Where(x => x.Area.Contains(param.Value));
                }
                else if (param.Key == "CostUpperLimit")
                {
                    searchFilter &= filter.Where(x => x.CostUpperLimit <= Convert.ToInt32(param.Value));
                }
                else if (param.Key == "CostLowerLimit")
                {
                    searchFilter &= filter.Where(x => x.CostLowerLimit >= Convert.ToInt32(param.Value));
                }


                foreach (var tag in Tags.GetTags())
                {
                    if (param.Key == tag && param.Value == "true")
                    {
                        tagsParams.Add(tag);
                    }
                }
                foreach(var cuisine in Cuisines.GetCusines())
                {
                    if (param.Key == cuisine && param.Value == "true")
                    {
                        cuisineParams.Add(cuisine);
                    }
                }
                
                
                
            }
  
            searchFilter &= filter.In("Tags", tagsParams);
            searchFilter &= filter.In("Cuisines", cuisineParams);
            return searchFilter;
        }        
    }
}
