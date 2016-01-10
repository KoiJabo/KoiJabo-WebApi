using koi_jabo.Entity;
using koi_jabo.Models.GeoJson;
using koi_jabo.Models.OpenCloseTime;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koi_jabo.Models
{
    public class RestaurantFormValue
    {
        public string name { get; set; }
        public string value { get; set; }

        public RestaurantEntity ParseFormValueToModel(List<RestaurantFormValue> value)
        {
            var model = new RestaurantModel();
            var entity = new RestaurantEntity(model);

            entity.GoodFor = new List<string>();
            entity.CreditCards = new List<string>();
            entity.Cuisines = new List<string>();
            entity.EstablishmentType = new List<string>();

            var geoPoint = new Point();
            geoPoint.coordinates = new List<double>();
            double latitude = 0;
            double longitude = 0;

            entity.GeoPoint = geoPoint;


            List<OpenCloseTimeModel> week = new List<OpenCloseTimeModel>();
            week.Add(new OpenCloseTimeModel() { Day = DayOfWeek.Saturday });
            week.Add(new OpenCloseTimeModel() { Day = DayOfWeek.Sunday });
            week.Add(new OpenCloseTimeModel() { Day = DayOfWeek.Monday });
            week.Add(new OpenCloseTimeModel() { Day = DayOfWeek.Tuesday });
            week.Add(new OpenCloseTimeModel() { Day = DayOfWeek.Wednesday });
            week.Add(new OpenCloseTimeModel() { Day = DayOfWeek.Thursday });
            week.Add(new OpenCloseTimeModel() { Day = DayOfWeek.Friday });

            entity.TimeTable = week;

            foreach (var item in value)
            {
                if (item.name == "_id")
                    entity._id = item.value;
                if (item.name == "Name")
                    entity.Name = item.value;
                if (item.name == "Area") entity.Area = item.value;
                if (item.name == "Address") entity.Address = item.value;
                if (item.name == "Latitude")
                    latitude= Convert.ToDouble(item.value);
                if (item.name == "Longitude")
                    longitude = Convert.ToDouble(item.value);


                if (item.name == "SaturdayStartTime")
                    entity.TimeTable[0].StartTime = Convert.ToInt32(item.value);
                if (item.name == "SaturdayStopTime")
                    entity.TimeTable[0].EndTime = Convert.ToInt32(item.value);

                if (item.name == "SundayStartTime")
                    entity.TimeTable[1].StartTime = Convert.ToInt32(item.value);
                if (item.name == "SundayStopTime")
                    entity.TimeTable[1].EndTime = Convert.ToInt32(item.value);

                if (item.name == "MondayStartTime")
                    entity.TimeTable[2].StartTime = Convert.ToInt32(item.value);
                if (item.name == "MondayStopTime")
                    entity.TimeTable[2].EndTime = Convert.ToInt32(item.value);

                if (item.name == "TuesdayStartTime")
                    entity.TimeTable[3].StartTime = Convert.ToInt32(item.value);
                if (item.name == "TuesdayStopTime")
                    entity.TimeTable[3].EndTime = Convert.ToInt32(item.value);

                if (item.name == "WednesdayStartTime")
                    entity.TimeTable[4].StartTime = Convert.ToInt32(item.value);
                if (item.name == "WednesdayStopTime")
                    entity.TimeTable[4].EndTime = Convert.ToInt32(item.value);

                if (item.name == "ThursdayStartTime")
                    entity.TimeTable[5].StartTime = Convert.ToInt32(item.value);
                if (item.name == "ThursdayStopTime")
                    entity.TimeTable[5].EndTime = Convert.ToInt32(item.value);

                if (item.name == "FridayStartTime")
                    entity.TimeTable[6].StartTime = Convert.ToInt32(item.value);
                if (item.name == "FridayStopTime")
                    entity.TimeTable[6].EndTime = Convert.ToInt32(item.value);

                

                if (item.name == "PhoneNumber") entity.PhoneNumber = item.value;
                if (item.name == "CostUpperLimit") entity.CostUpperLimit = Convert.ToInt32(item.value);
                if (item.name == "CostLowerLimit") entity.CostLowerLimit = Convert.ToInt32(item.value);

                if (item.name == "CreditCards") entity.CreditCards.Add(item.value);
                if (item.name == "GoodFor") entity.GoodFor.Add(item.value);
                if (item.name == "Cuisines") entity.Cuisines.Add(item.value);
                if (item.name == "EstablishmentType") entity.EstablishmentType.Add(item.value);
                

                if (item.name == "Parking") entity.Parking = item.value;
                if (item.name == "Attire") entity.Attire = item.value;
                if (item.name == "NoiseLevel") entity.NoiseLevel = item.value;

                if (item.name == "Rooftop") entity.Rooftop = StringToBoolean(item.value);
                if (item.name == "Reservation") entity.Reservation = StringToBoolean(item.value);
                if (item.name == "Delivery") entity.Delivery = StringToBoolean(item.value);
                if (item.name == "TakeOut") entity.TakeOut = StringToBoolean(item.value);
                if (item.name == "OutDoor") entity.OutDoor = StringToBoolean(item.value);
                if (item.name == "Wifi") entity.Wifi = StringToBoolean(item.value);
                if (item.name == "Tv") entity.Tv = StringToBoolean(item.value);
                if (item.name == "CandleLight") entity.CandleLight = StringToBoolean(item.value);
                if (item.name == "LuxuryDining") entity.LuxuryDining = StringToBoolean(item.value);
                if (item.name == "Washroom") entity.Washroom = StringToBoolean(item.value);
                if (item.name == "Toilet") entity.Toilet = StringToBoolean(item.value);
                

            }

            entity.GeoPoint.coordinates.Add(longitude);
            entity.GeoPoint.coordinates.Add(latitude);

            string json = JsonConvert.SerializeObject(entity);
            return entity;
        }

        private bool StringToBoolean(string value)
        {
            if (value.Contains("true")) return true;
            else return false;
            
        }
    }
}
