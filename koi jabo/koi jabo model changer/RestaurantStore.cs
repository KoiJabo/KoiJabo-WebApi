using koi_jabo.Entity;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koi_jabo_model_changer
{
    class RestaurantStore
    {
        KoiJaboMongoDataContext context = new KoiJaboMongoDataContext();
        internal async Task<List<NewEntity>> Search()
        {
            var Collection = context.Database.GetCollection<RestaurantEntity>("Restaurants");
            var searchResult = await Collection.Find(new BsonDocument()).ToListAsync();

            List<NewEntity> newEntity = new List<NewEntity>();
            foreach (var model in searchResult)
            {
                var newentity = new NewEntity();
                newentity.TagsFalse = new List<string>();
                newentity.TagsTrue = new List<string>();

                newentity.Name = model.Name;
                newentity.Address = model.Address;
                newentity.Area = model.Area;
                newentity.TitleImageUrl = model.TitleImageUrl;
                newentity.TimeTable = model.TimeTable;
                newentity.GeoPoint = model.GeoPoint;
                newentity.GeneralRatingRating = model.GeneralRatingRating;
                newentity.AmbienceRating = model.AmbienceRating;
                newentity.ServiceRating = model.ServiceRating;
                newentity.FoodRating = model.FoodRating;
                newentity.PhoneNumber = model.PhoneNumber;

                newentity.CostPerPerson = model.CostLowerLimit.ToString() + " - " + model.CostUpperLimit.ToString() + " taka"; ;
                newentity.CostUpperLimit = model.CostUpperLimit;
                newentity.CostLowerLimit = model.CostLowerLimit;

                newentity.CreditCards = model.CreditCards;
                newentity.GoodFor = model.GoodFor;
                newentity.Cuisines = model.Cuisines;
                newentity.EstablishmentType = model.EstablishmentType;

                
                newentity.Parking = model.Parking;
                newentity.Attire = model.Attire;
                newentity.NoiseLevel = model.NoiseLevel;

                 

                newEntity.Add(newentity);

                await Create(newentity);
            }

            var json = JsonConvert.SerializeObject(newEntity);
            File.WriteAllText(@"D:\restaurant.json", json);
            return newEntity;
        }



        internal async Task<NewEntity> Create(NewEntity entity)
        {
            await context.NewEntitys.InsertOneAsync(entity);
            return entity;

        }
    }
}
