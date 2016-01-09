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

        public RestaurantModel ParseFormValueToModel(List<RestaurantFormValue> value)
        {
            var model = new RestaurantModel();

            model.GoodFor = new List<string>();
            model.CreditCards = new List<string>();
            model.Cuisines = new List<string>();
            model.EstablishmentType = new List<string>();

            var geoPoint = new Point();
            geoPoint.coordinates = new List<double>();
            double latitude = 0;
            double longitude = 0;

            model.GeoPoint = geoPoint;


            List<OpenCloseTimeModel> week = new List<OpenCloseTimeModel>();
            week.Add(new OpenCloseTimeModel() { Day = DayOfWeek.Saturday });
            week.Add(new OpenCloseTimeModel() { Day = DayOfWeek.Sunday });
            week.Add(new OpenCloseTimeModel() { Day = DayOfWeek.Monday });
            week.Add(new OpenCloseTimeModel() { Day = DayOfWeek.Tuesday });
            week.Add(new OpenCloseTimeModel() { Day = DayOfWeek.Wednesday });
            week.Add(new OpenCloseTimeModel() { Day = DayOfWeek.Thursday });
            week.Add(new OpenCloseTimeModel() { Day = DayOfWeek.Friday });

            model.TimeTable = week;

            foreach (var item in value)
            {
                if (item.name == "Name")
                    model.Name = item.value;
                if (item.name == "Area") model.Area = item.value;
                if (item.name == "Address") model.Address = item.value;
                if (item.name == "Latitude")
                    latitude= Convert.ToDouble(item.value);
                if (item.name == "Longitude")
                    longitude = Convert.ToDouble(item.value);


                if (item.name == "SaturdayStartTime")
                    model.TimeTable[0].StartTime = Convert.ToInt32(item.value);
                if (item.name == "SaturdayStopTime")
                    model.TimeTable[0].EndTime = Convert.ToInt32(item.value);

                if (item.name == "SundayStartTime")
                    model.TimeTable[1].StartTime = Convert.ToInt32(item.value);
                if (item.name == "SundayStopTime")
                    model.TimeTable[1].EndTime = Convert.ToInt32(item.value);

                if (item.name == "MondayStartTime")
                    model.TimeTable[2].StartTime = Convert.ToInt32(item.value);
                if (item.name == "MondayStopTime")
                    model.TimeTable[2].EndTime = Convert.ToInt32(item.value);

                if (item.name == "TuesdayStartTime")
                    model.TimeTable[3].StartTime = Convert.ToInt32(item.value);
                if (item.name == "TuesdayStopTime")
                    model.TimeTable[3].EndTime = Convert.ToInt32(item.value);

                if (item.name == "WednesdayStartTime")
                    model.TimeTable[4].StartTime = Convert.ToInt32(item.value);
                if (item.name == "WednesdayStopTime")
                    model.TimeTable[4].EndTime = Convert.ToInt32(item.value);

                if (item.name == "ThursdayStartTime")
                    model.TimeTable[5].StartTime = Convert.ToInt32(item.value);
                if (item.name == "ThursdayStopTime")
                    model.TimeTable[5].EndTime = Convert.ToInt32(item.value);

                if (item.name == "FridayStartTime")
                    model.TimeTable[6].StartTime = Convert.ToInt32(item.value);
                if (item.name == "FridayStopTime")
                    model.TimeTable[6].EndTime = Convert.ToInt32(item.value);

                

                if (item.name == "PhoneNumber") model.PhoneNumber = item.value;
                if (item.name == "CostUpperLimit") model.CostUpperLimit = Convert.ToInt32(item.value);
                if (item.name == "CostLowerLimit") model.CostLowerLimit = Convert.ToInt32(item.value);

                if (item.name == "CreditCards") model.CreditCards.Add(item.value);
                if (item.name == "GoodFor") model.GoodFor.Add(item.value);
                if (item.name == "Cuisines") model.Cuisines.Add(item.value);
                if (item.name == "EstablishmentType") model.EstablishmentType.Add(item.value);
                

                if (item.name == "Parking") model.Parking = item.value;
                if (item.name == "Attire") model.Attire = item.value;
                if (item.name == "NoiseLevel") model.NoiseLevel = item.value;

                if (item.name == "Rooftop") model.Rooftop = StringToBoolean(item.value);
                if (item.name == "Reservation") model.Reservation = StringToBoolean(item.value);
                if (item.name == "Delivery") model.Delivery = StringToBoolean(item.value);
                if (item.name == "TakeOut") model.TakeOut = StringToBoolean(item.value);
                if (item.name == "OutDoor") model.OutDoor = StringToBoolean(item.value);
                if (item.name == "Wifi") model.Wifi = StringToBoolean(item.value);
                if (item.name == "Tv") model.Tv = StringToBoolean(item.value);
                if (item.name == "CandleLight") model.CandleLight = StringToBoolean(item.value);
                if (item.name == "LuxuryDining") model.LuxuryDining = StringToBoolean(item.value);
                if (item.name == "Washroom") model.Washroom = StringToBoolean(item.value);
                if (item.name == "Toilet") model.Toilet = StringToBoolean(item.value);
                

            }

            model.GeoPoint.coordinates.Add(longitude);
            model.GeoPoint.coordinates.Add(latitude);

            string json = JsonConvert.SerializeObject(model);
            return model;
        }

        private bool StringToBoolean(string value)
        {
            if (value.Contains("true")) return true;
            else return false;
            
        }
    }
}
