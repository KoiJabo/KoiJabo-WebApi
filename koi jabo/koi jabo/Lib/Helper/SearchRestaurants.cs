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
 

            int maxDistanceinMeter = 0;
            int minDistanceinMeter = 0;

            double latitude = 0;
            double longitude = 0;


           

            foreach (var param in QueryParameters)
            {
                 
                if(param.Key == "Value")
                {
                    searchFilter &= filter.Text(param.Value);
                }
                
                else if (param.Key == "CostUpperLimit")
                {
                    searchFilter &= filter.Where(x => x.CostUpperLimit <= Convert.ToInt32(param.Value));
                }
                else if (param.Key == "CostLowerLimit")
                {
                    searchFilter &= filter.Where(x => x.CostLowerLimit >= Convert.ToInt32(param.Value));
                }
                else if (param.Key == "Latitude")
                {
                    latitude = Convert.ToDouble(param.Value);
                }
                else if (param.Key == "Longitude")
                {
                    longitude = Convert.ToDouble(param.Value);
                }
                else if (param.Key == "MaxDistance")
                {
                    maxDistanceinMeter = Convert.ToInt32(param.Value);
                }
                else if (param.Key == "MinDistance")
                {
                    minDistanceinMeter = Convert.ToInt32(param.Value);
                }
            }

            if (latitude != 0 && longitude != 0)
            {
                GeoJsonPoint<GeoJson2DGeographicCoordinates> Point = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(new GeoJson2DGeographicCoordinates(longitude, latitude));
                FilterDefinitionBuilder<RestaurantEntity> builder = new FilterDefinitionBuilder<RestaurantEntity>();
                searchFilter &= builder.Near<GeoJson2DGeographicCoordinates>(x => x.GeoPoint, Point, maxDistanceinMeter);
            }
            
            
            return searchFilter;
        }        
    }
}
