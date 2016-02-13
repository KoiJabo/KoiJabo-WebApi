using koi_jabo.Entity;
using koi_jabo.Models;
using koi_jabo.Models.GeoJson;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koi_jabo.Lib.Helper
{
    public static class SearchRestaurants
    {        
        public static FilterDefinition<RestaurantEntity> GetSearchFilter(Dictionary<string, string> QueryParameters)
        {
            FilterDefinition<RestaurantEntity> searchFilter;
           
            if (QueryParameters.Count == 0)
            {
                BsonDocument nofilter = new BsonDocument();
                return nofilter;
            }


            searchFilter = Builders<RestaurantEntity>.Filter.Where(x => x.Name != null);
            var filter = Builders<RestaurantEntity>.Filter;
 

            int distanceInMeter = 0;
            int minDistanceinMeter = 0;

            double latitude = 0;
            double longitude = 0;


           

            foreach (var param in QueryParameters)
            {
                 
                if(param.Key == "value")
                {
                    if (param.Value!="")
                    {
                        searchFilter &= filter.Text(param.Value);                        
                    }
                }
                
                else if (param.Key == "costupperlimit")
                {
                    searchFilter &= filter.Where(x => x.CostUpperLimit <= Convert.ToInt32(param.Value));
                }
                else if (param.Key == "costlowerlimit")
                {
                    searchFilter &= filter.Where(x => x.CostLowerLimit >= Convert.ToInt32(param.Value));
                }
                else if (param.Key == "lat")
                {
                    latitude = Convert.ToDouble(param.Value);
                }
                else if (param.Key == "lon")
                {
                    longitude = Convert.ToDouble(param.Value);
                }
                else if (param.Key == "distance")
                {
                    distanceInMeter = Convert.ToInt32(param.Value);
                }
            }

            if (latitude != 0 && longitude != 0)
            {
                GeoJsonPoint<GeoJson2DGeographicCoordinates> Point = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(new GeoJson2DGeographicCoordinates(longitude, latitude));
                FilterDefinitionBuilder<RestaurantEntity> builder = new FilterDefinitionBuilder<RestaurantEntity>();
                searchFilter &= builder.Near<GeoJson2DGeographicCoordinates>(x => x.GeoPoint, Point, distanceInMeter);
            }
            
            
            return searchFilter;
        }
    }
}
