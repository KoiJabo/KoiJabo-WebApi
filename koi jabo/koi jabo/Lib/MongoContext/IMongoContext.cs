using koi_jabo.Entity;
using koi_jabo_models.Entity;
using MongoDB.Driver;

namespace koi_jabo.Lib.MongoContext
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }

        IMongoCollection<RestaurantEntity> Restaurants { get; }
        IMongoCollection<ReviewEntity> Reviews { get; }
        IMongoCollection<UserEntity> Users { get; }
        IMongoCollection<OptionsForDashBoardEntity> OptionsForDashBoard { get; }
    }
}
