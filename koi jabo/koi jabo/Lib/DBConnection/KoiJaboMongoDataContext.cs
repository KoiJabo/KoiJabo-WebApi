using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using koi_jabo.Entity;
using MongoDB.Driver;
using System.Configuration;

namespace koi_jabo.Lib.DBConnection
{
    class KoiJaboMongoDataContext : IMongoContext
    {
        public IMongoDatabase Database { get; private set; }

        private IMongoCollection<RestaurantEntity> _restaurants;
        public IMongoCollection<RestaurantEntity> Restaurants { get { return _restaurants; } }

        public KoiJaboMongoDataContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["KoijaboMongo.ConnectionString"].ConnectionString;
            var mongoUrlBuilder = new MongoUrlBuilder(connectionString);
            var mongoClient = new MongoClient(mongoUrlBuilder.ToMongoUrl());

            Database = mongoClient.GetDatabase(mongoUrlBuilder.DatabaseName);

            _restaurants = Database.GetCollection<RestaurantEntity>(MongoCollectionNames.RestaurantsCollectionName);
        }
    }
}
