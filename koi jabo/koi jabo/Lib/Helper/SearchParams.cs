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
        public static FilterDefinition<BsonDocument> GetSearchFilter(IEnumerable<KeyValuePair<string, string>> QueryParameters)
        {
            var filterQuery = Builders<BsonDocument>.Filter;
            
            if (QueryParameters == null)
            {
                BsonDocument nofilter = new BsonDocument();
                return nofilter;
            }

            FilterDefinition<BsonDocument> searchFilter = "{}";

            string query = "";
            foreach (var param in QueryParameters)
            {
                if (param.Value == "true")
                {
                    query += "{" + "\"" + param.Key + "\"" + ":" + "true" + "},";   
                }
                else if (param.Key.Contains("Name") || param.Key.Contains("Area"))                
                {
                    query += "{" + "\"" + param.Key + "\"" + ":" + "/"+ param.Value +"/" + "},";
                }
                else if (param.Key.Contains("CostUpperLimit"))
                {
                    query += "{" + "\"" + param.Key + "\"" + ": { $lte: " + Convert.ToDouble(param.Value) + "}},";
                }                 
            }
            query = query.Substring(0, query.Length - 1);


            return query;
        }
    }
}
