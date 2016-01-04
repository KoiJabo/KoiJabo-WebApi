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
            var cuisineParams = new List<string>();
            var creaditCardParams = new List<string>();
            var goodForParams = new List<string>();

            int maxDistanceinMeter = 0;
            int minDistanceinMeter = 0;

            double latitude = 0;
            double longitude = 0;


           

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

                foreach (var tag in ListOptions.GetCreditCards())
                {
                    if (param.Key == tag && param.Value == "true")
                    {
                        creaditCardParams.Add(tag);
                    }
                }

                foreach (var tag in ListOptions.GetGoodForList())
                {
                    if (param.Key == tag && param.Value == "true")
                    {
                        goodForParams.Add(tag);
                    }
                }

                foreach (var cuisine in ListOptions.GetCusines())
                {
                    if (param.Key == cuisine && param.Value == "true")
                    {
                        cuisineParams.Add(cuisine);
                    }
                }
            }

            if (latitude != 0 && longitude != 0)
            {
                GeoJsonPoint<GeoJson2DGeographicCoordinates> Point = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(new GeoJson2DGeographicCoordinates(longitude, latitude));
                FilterDefinitionBuilder<RestaurantEntity> builder = new FilterDefinitionBuilder<RestaurantEntity>();
                searchFilter &= builder.Near<GeoJson2DGeographicCoordinates>(x => x.GeoPoint, Point, maxDistanceinMeter);
            }
            if (creaditCardParams.Count != 0)
            {
                searchFilter &= filter.In("CreditCards", creaditCardParams);
            }
            if (goodForParams.Count != 0)
            {
                searchFilter &= filter.In("GoodFor", goodForParams);
            }
            if (cuisineParams.Count != 0)
            {
                searchFilter &= filter.In("Cuisines", cuisineParams);
            }
            
            return searchFilter;
        }        
    }
}
