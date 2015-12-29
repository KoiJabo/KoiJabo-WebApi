using koi_jabo.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koi_jabo.Lib.DBConnection
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }

        IMongoCollection<RestaurantEntity> Restaurants { get; }
    }
}
