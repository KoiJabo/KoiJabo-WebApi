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

                if (model.Rooftop)
                    newentity.TagsTrue.Add("Rooftop");
                else if (!model.Rooftop)
                    newentity.TagsFalse.Add("Rooftop");
                if (model.Reservation)
                    newentity.TagsTrue.Add("Reservation");
                else if (!model.Reservation)
                    newentity.TagsFalse.Add("Reservation");
                if (model.Delivery)
                    newentity.TagsTrue.Add("Delivery");
                else if (!model.Delivery)
                    newentity.TagsFalse.Add("Delivery");
                if (model.TakeOut)
                    newentity.TagsTrue.Add("TakeOut");
                else if (!model.TakeOut)
                    newentity.TagsFalse.Add("TakeOut");
                if (model.OutDoor)
                    newentity.TagsTrue.Add("OutDoor");
                else if (!model.OutDoor)
                    newentity.TagsFalse.Add("OutDoor");
                if (model.Wifi)
                    newentity.TagsTrue.Add("Wifi");
                else if (!model.Wifi)
                    newentity.TagsFalse.Add("Wifi");
                if (model.Tv)
                    newentity.TagsTrue.Add("Tv");
                else if (!model.Tv)
                    newentity.TagsFalse.Add("Tv");
                if (model.CandleLight)
                    newentity.TagsTrue.Add("CandleLight");
                else if (!model.CandleLight)
                    newentity.TagsFalse.Add("CandleLight");
                if (model.LuxuryDining)
                    newentity.TagsTrue.Add("LuxuryDining");
                else if (!model.LuxuryDining)
                    newentity.TagsFalse.Add("LuxuryDining");
                if (model.Washroom)
                    newentity.TagsTrue.Add("Washroom");
                else if (!model.Washroom)
                    newentity.TagsFalse.Add("Washroom");
                if (model.Toilet)
                    newentity.TagsTrue.Add("Toilet");
                else if (!model.Toilet)
                    newentity.TagsFalse.Add("Toilet");

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
