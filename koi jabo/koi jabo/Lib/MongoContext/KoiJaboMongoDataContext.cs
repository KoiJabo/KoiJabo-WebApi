using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using koi_jabo.Entity;
using MongoDB.Driver;
using System.Configuration;

namespace koi_jabo.Lib.MongoContext
{
    class KoiJaboMongoDataContext : IMongoContext
    {
        public IMongoDatabase Database { get; private set; }

        private IMongoCollection<RestaurantEntity> _restaurants;
        public IMongoCollection<RestaurantEntity> Restaurants { get { return _restaurants; } }

        private IMongoCollection<ReviewEntity> _reviews;
        public IMongoCollection<ReviewEntity> Reviews { get { return _reviews; } }

        private IMongoCollection<UserEntity> _users;
        public IMongoCollection<UserEntity> Users { get { return _users; } }

        public KoiJaboMongoDataContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["KoijaboMongo.ConnectionString"].ConnectionString;
            var mongoUrlBuilder = new MongoUrlBuilder(connectionString);
            var mongoClient = new MongoClient(mongoUrlBuilder.ToMongoUrl());

            Database = mongoClient.GetDatabase(mongoUrlBuilder.DatabaseName);

            _restaurants = Database.GetCollection<RestaurantEntity>(MongoCollectionNames.RestaurantsCollectionName);
            _reviews = Database.GetCollection<ReviewEntity>(MongoCollectionNames.ReviewsCollectionName);
            _users = Database.GetCollection<UserEntity>(MongoCollectionNames.UsersCollectionName);

            CreateIndexOptions GeoSphereindexOptions = new CreateIndexOptions();
            GeoSphereindexOptions.SphereIndexVersion = 2;
            _restaurants.Indexes.CreateOneAsync(Builders<RestaurantEntity>.IndexKeys.Geo2DSphere(x => x.GeoPoint), GeoSphereindexOptions);

            CreateIndexOptions TextindexOptions = new CreateIndexOptions();

            _restaurants.Indexes.CreateOneAsync(Builders<RestaurantEntity>.IndexKeys.Text(x => x.Name), TextindexOptions);
            _restaurants.Indexes.CreateOneAsync(Builders<RestaurantEntity>.IndexKeys.Text(x => x.Area), TextindexOptions);
            _restaurants.Indexes.CreateOneAsync(Builders<RestaurantEntity>.IndexKeys.Text(x => x.Address), TextindexOptions);
            _restaurants.Indexes.CreateOneAsync(Builders<RestaurantEntity>.IndexKeys.Text(x => x.PhoneNumber), TextindexOptions);
            _restaurants.Indexes.CreateOneAsync(Builders<RestaurantEntity>.IndexKeys.Text(x => x.CreditCards), TextindexOptions);
            _restaurants.Indexes.CreateOneAsync(Builders<RestaurantEntity>.IndexKeys.Text(x => x.GoodFor), TextindexOptions);
            _restaurants.Indexes.CreateOneAsync(Builders<RestaurantEntity>.IndexKeys.Text(x => x.Cuisines), TextindexOptions);
            _restaurants.Indexes.CreateOneAsync(Builders<RestaurantEntity>.IndexKeys.Text(x => x.EstablishmentType), TextindexOptions);
            _restaurants.Indexes.CreateOneAsync(Builders<RestaurantEntity>.IndexKeys.Text(x => x.Parking), TextindexOptions);
            _restaurants.Indexes.CreateOneAsync(Builders<RestaurantEntity>.IndexKeys.Text(x => x.Attire), TextindexOptions);
            _restaurants.Indexes.CreateOneAsync(Builders<RestaurantEntity>.IndexKeys.Text(x => x.NoiseLevel), TextindexOptions);
            _restaurants.Indexes.CreateOneAsync(Builders<RestaurantEntity>.IndexKeys.Text(x => x.TagsTrue), TextindexOptions);
            _restaurants.Indexes.CreateOneAsync(Builders<RestaurantEntity>.IndexKeys.Text(x => x.TagsFalse), TextindexOptions);
        }
    }
}
