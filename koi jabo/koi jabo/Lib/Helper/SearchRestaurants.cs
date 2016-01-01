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

            // NEED TO FIX THIS, TO DETERMINE THAT THE QUERYSTRINGPARAMTER DOESN'T CONTAIN ANY PARAM
            
            if (QueryParameters.Count == 0)
            {
                BsonDocument nofilter = new BsonDocument();
                return nofilter;
            }


            searchFilter = Builders<RestaurantEntity>.Filter.Where(x => x.Name != null);
            var filter = Builders<RestaurantEntity>.Filter;
            var tagsParams = new List<string>();
            var cuisineParams = new List<string>();
            int maxDistanceinMeter = 0;
            int minDistanceinMeter = 0;

            var location = new Point();
            location.coordinates = new List<double>();
            location.coordinates.Add(0);
            location.coordinates.Add(0);


            bool latitudeExist = false;
            bool longitudedeExist = false;

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
                else if (param.Key == "Latitude")
                {
                    latitudeExist = true;
                    location.coordinates[1] = Convert.ToDouble(param.Value);
                }
                else if (param.Key == "Longitude")
                {
                    longitudedeExist = true;
                    location.coordinates[0] = Convert.ToDouble(param.Value);
                }
                else if (param.Key == "MaxDistance")
                {
                    maxDistanceinMeter = Convert.ToInt32(param.Value);
                }
                else if (param.Key == "MinDistance")
                {
                    minDistanceinMeter = Convert.ToInt32(param.Value);
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

            if (latitudeExist && longitudedeExist)
            {
                var lon = location.coordinates[0];
                var lat = location.coordinates[1];
                GeoJsonPoint<GeoJson2DGeographicCoordinates> Point = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(new GeoJson2DGeographicCoordinates(lon, lat));
                FilterDefinitionBuilder<RestaurantEntity> builder = new FilterDefinitionBuilder<RestaurantEntity>();
                searchFilter &= builder.Near<GeoJson2DGeographicCoordinates>(x => x.GeoPoint, Point, maxDistanceinMeter);
            }
            if (tagsParams.Count != 0)
            {
                searchFilter &= filter.In("Tags", tagsParams);
            }
            if (cuisineParams.Count != 0)
            {
                searchFilter &= filter.In("Cuisines", cuisineParams);
            }
            
            return searchFilter;
        }        
    }
}
