using koi_jabo.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koi_jabo_model_changer
{
    class KoiJaboMongoDataContext
    {
        public static readonly string RestaurantsCollectionName = "Restaurants";
        public static readonly string NewRestaurantCollectionName = "NewRestaurants";
        public static readonly string ReviewsCollectionName = "Reviews";
        public static readonly string UsersCollectionName = "Users";
        public IMongoDatabase Database { get; private set; }

        private IMongoCollection<NewEntity> _restaurants;
        public IMongoCollection<NewEntity> Restaurants { get { return _restaurants; } }

        private IMongoCollection<ReviewEntity> _reviews;
        public IMongoCollection<ReviewEntity> Reviews { get { return _reviews; } }

        private IMongoCollection<UserEntity> _users;
        public IMongoCollection<UserEntity> Users { get { return _users; } }


        private IMongoCollection<NewEntity> _newentity;
        public IMongoCollection<NewEntity> NewEntitys { get { return _newentity; } }

        public KoiJaboMongoDataContext()
        {
            var connectionString = "mongodb://tareq:123456@koijabo-api.cloudapp.net:27017/koijabo";
            var mongoUrlBuilder = new MongoUrlBuilder(connectionString);
            var mongoClient = new MongoClient(mongoUrlBuilder.ToMongoUrl());

            Database = mongoClient.GetDatabase(mongoUrlBuilder.DatabaseName);

            _restaurants = Database.GetCollection<NewEntity>(RestaurantsCollectionName);
            _reviews = Database.GetCollection<ReviewEntity>(ReviewsCollectionName);
            _users = Database.GetCollection<UserEntity>(UsersCollectionName);

            _newentity = Database.GetCollection<NewEntity>(NewRestaurantCollectionName);

            CreateIndexOptions GeoSphereindexOptions = new CreateIndexOptions();
            GeoSphereindexOptions.SphereIndexVersion = 2;
            _restaurants.Indexes.CreateOneAsync(Builders<NewEntity>.IndexKeys.Geo2DSphere(x => x.GeoPoint), GeoSphereindexOptions);
        }
    }
}
