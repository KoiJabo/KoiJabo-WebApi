using koi_jabo.Entity;
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
    public class SearchParams
    {
        public static FilterDefinition<RestaurantEntity> GetSearchFilter(IEnumerable<KeyValuePair<string, string>> QueryParameters)
        {
            FilterDefinition<RestaurantEntity> searchFilter;
            if (QueryParameters == null)
            {
                BsonDocument nofilter = new BsonDocument();
                return nofilter;
            }
            /*Area
            TimeTable
            GeneralRatingRating
            AmbienceRating
            ServiceRating
            FoodRating
            CostRating
            PhoneNumber
            CostPerPerson
            TakeReservations
            Delivery
            OutdoorSeating
            Casual
            Gossip
            Hangout
            Meetings
            Visa
            Master
            Nexus
            AmericanExpress
            Parking
            Ac*/
            searchFilter = Builders<RestaurantEntity>.Filter.Where(x => x.Name != null);

            foreach (var param in QueryParameters)
            {
                if (param.Key == "Name")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.Name.Contains(param.Value));
                }
                else if (param.Key == "Area")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.Area.Contains(param.Value));
                }
                else if (param.Key == "CostUpperLimit")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.CostUpperLimit <= Convert.ToInt32(param.Value));
                }
                else if (param.Key == "TakeReservations" && param.Value == "true")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.TakeReservations == true);
                }
                else if (param.Key == "Delivery" && param.Value == "true")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.Delivery == true);
                }
                else if (param.Key == "OutdoorSeating" && param.Value == "true")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.OutdoorSeating == true);
                }
                else if (param.Key == "Casual" && param.Value == "true")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.Casual == true);
                }
                else if (param.Key == "Gossip" && param.Value == "true")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.Gossip == true);
                }
                else if (param.Key == "Hangout" && param.Value == "true")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.Hangout == true);
                }
                else if (param.Key == "Meetings" && param.Value == "true")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.Meetings == true);
                }
                else if (param.Key == "Visa" && param.Value == "true")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.Visa == true);
                }
                else if (param.Key == "Master" && param.Value == "true")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.Master == true);
                }
                else if (param.Key == "Nexus" && param.Value == "true")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.Nexus == true);
                }
                else if (param.Key == "AmericanExpress" && param.Value == "true")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.AmericanExpress == true);
                }
                else if (param.Key == "Parking" && param.Value == "true")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.Parking == true);
                }
                else if (param.Key == "Ac" && param.Value == "true")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.Ac == true);
                }                
                else if (param.Key == "TakeReservations" && param.Value == "true")
                {
                    searchFilter &= Builders<RestaurantEntity>.Filter.Where(x => x.TakeReservations == true);                    
                }
            }
            return searchFilter;
        }
    }
}
