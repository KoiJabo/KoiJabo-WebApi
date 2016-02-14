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
            var Collection = context.Database.GetCollection<RestaurantEntity>("NewRestaurants");
            List<RestaurantEntity> searchResult = new List<RestaurantEntity>();
            try
            {
                searchResult = await Collection.Find(new BsonDocument()).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            List<NewEntity> newEntity = new List<NewEntity>();
            try
            {                
                foreach (var model in searchResult)
                {
                    var newentity = new NewEntity();
                    newentity.TagsFalse = new List<string>();
                    newentity.TagsTrue = new List<string>();

                    newentity.Name = model.Name;

                    Console.WriteLine(newentity.Name);

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

                    newentity.TagsFalse = model.TagsFalse;
                    newentity.TagsTrue = model.TagsTrue;

                    newentity.SearchTags = new List<string>();

                    if (model.Name != null)
                    {
                        newentity.SearchTags.Add(model.Name.ToLower());
                    }

                    if (model.Area != null)
                    {
                        newentity.SearchTags.Add(model.Area.ToLower());
                    }

                    if (model.PhoneNumber != null)
                    {
                        newentity.SearchTags.Add(model.PhoneNumber.ToLower());
                    }

                    if (model.Parking != null)
                    {
                        newentity.SearchTags.Add(model.Parking.ToLower());
                    }

                    if (model.NoiseLevel != null)
                    {
                        newentity.SearchTags.Add(model.NoiseLevel.ToLower());
                    }
                    if (model.Attire != null)
                    {
                        newentity.SearchTags.Add(model.Attire.ToLower());
                    }


                    foreach (var item in model.Cuisines)
                    {
                        if (item != null)
                        {

                        }
                        newentity.SearchTags.Add(item.ToLower());
                    }
                    foreach (var item in model.GoodFor)
                    {
                        if (item != null)
                        {
                            newentity.SearchTags.Add(item.ToLower());
                        }

                    }
                    foreach (var item in model.EstablishmentType)
                    {
                        if (item != null)
                        {
                            newentity.SearchTags.Add(item.ToLower());
                        }

                    }
                    foreach (var item in model.TagsTrue)
                    {
                        if (item != null)
                        {
                            newentity.SearchTags.Add(item.ToLower());
                        }

                    }
                    foreach (var item in model.CreditCards)
                    {
                        if (item != null)
                        {
                            newentity.SearchTags.Add(item.ToLower());
                        }
                    }

                    newEntity.Add(newentity);

                    await Create(newentity);
                }

                var json = JsonConvert.SerializeObject(newEntity);
                File.WriteAllText(@"D:\restaurantwithTags.json", json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
            
            return newEntity;
        }



        internal async Task<NewEntity> Create(NewEntity entity)
        {
            await context.Restaurants.InsertOneAsync(entity);
            return entity;

        }
    }
}
