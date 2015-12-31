using koi_jabo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace koi_jabo.Lib.Helper
{
    public static class OpenOrCloseDetector
    {
        public static bool Detect(RestaurantEntity entity)
        {
            var today = DateTime.Now.DayOfWeek;
            var hourNow = DateTime.Now.Hour;

            foreach (var item in entity.TimeTable)
            {
                if (item.Day == today)
                {
                    if (hourNow >= item.StartTime && hourNow <= item.EndTime)
                    {
                        return true;
                    }
                }
            }


            return false;
        }
    }
}