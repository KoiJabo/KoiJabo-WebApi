using koi_jabo.Models.GeoJson;
using koi_jabo.Models.OpenCloseTime;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koi_jabo_model_changer
{
    class NewModel
    {
         
        public string Name { get; set; }        
        public string Area { get; set; }       
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public Point GeoPoint { get; set; }
        public string Parking { get; set; }
        public string Attire { get; set; }
        public string NoiseLevel { get; set; }
        public string TitleImageUrl { get; set; }
        public int CostUpperLimit { get; set; }
        public int CostLowerLimit { get; set; }



        public double GeneralRatingRating { get; set; }
        public double AmbienceRating { get; set; }
        public double ServiceRating { get; set; }
        public double FoodRating { get; set; }
        
        

        public List<OpenCloseTimeModel> TimeTable { get; set; }
        public List<string> CreditCards { get; set; }
        public List<string> GoodFor { get; set; }
        public List<string> Cuisines { get; set; }
        public List<string> EstablishmentType { get; set; }
        public List<string> TagsTrue { get; set; }
        public List<string> TagsFalse { get; set; }


    }
    class NewEntity : NewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonIgnore]
        public bool IsOpenNow { get; set; }
        [BsonIgnore]
        public double Distance { get; set; }
        [BsonIgnore]
        public string CostPerPerson { get; set; }
        public int CostRating { get; set; }
        public NewEntity()
        {

        }
        public NewEntity(NewModel model)
        {
            this.Name = model.Name;
            this.Address = model.Address;
            this.Area = model.Area;
            this.TitleImageUrl = model.TitleImageUrl;
            this.TimeTable = model.TimeTable;
            this.GeoPoint = model.GeoPoint;
            this.GeneralRatingRating = model.GeneralRatingRating;
            this.AmbienceRating = model.AmbienceRating;
            this.ServiceRating = model.ServiceRating;
            this.FoodRating = model.FoodRating;
            this.PhoneNumber = model.PhoneNumber;

            this.CostPerPerson = model.CostLowerLimit.ToString() + " - " + model.CostUpperLimit.ToString() + " taka"; ;
            this.CostUpperLimit = model.CostUpperLimit;
            this.CostLowerLimit = model.CostLowerLimit;

            this.CreditCards = model.CreditCards;
            this.GoodFor = model.GoodFor;
            this.Cuisines = model.Cuisines;
            this.EstablishmentType = model.EstablishmentType;
            this.TagsTrue = model.TagsTrue;
            this.TagsFalse = model.TagsFalse;


            this.Parking = model.Parking;
            this.Attire = model.Attire;
            this.NoiseLevel = model.NoiseLevel;
        }
    }
}

