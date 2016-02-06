using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koi_jabo.Models
{
    public static class ListOptions
    {
        public static List<string> GetCusines()
        {
            List<string> cuisines = new List<string>();

            cuisines.Add("Afghani");
            cuisines.Add("Arabian");
            cuisines.Add("Asian");
            cuisines.Add("Bakery");
            cuisines.Add("Bengali");
            cuisines.Add("Beverages");
            cuisines.Add("Biriyani");
            cuisines.Add("Bufet");
            cuisines.Add("Burger");
            cuisines.Add("Cafe");
            cuisines.Add("Chinese");
            cuisines.Add("Desserts");
            cuisines.Add("FastFood");
            cuisines.Add("FoodCart");
            cuisines.Add("Hyderabadi");
            cuisines.Add("IceCream");
            cuisines.Add("Indian");
            cuisines.Add("Italian");
            cuisines.Add("Juices");
            cuisines.Add("Korean");
            cuisines.Add("Mediterranean");
            cuisines.Add("Mexican");
            cuisines.Add("MiddleEastern");
            cuisines.Add("Mughlai");
            cuisines.Add("NorthIndian");
            cuisines.Add("Pizza");
            cuisines.Add("Sandwich");
            cuisines.Add("SeaFood");
            cuisines.Add("Spanish");
            cuisines.Add("Steakhouse");
            cuisines.Add("StreetFood");
            cuisines.Add("Sushi");
            cuisines.Add("Thai");
            cuisines.Add("Turkish");
            return cuisines;
        }      

        public static List<string> GetEstablishmentTypes()
        {
            var establishmentTypeList = new List<string>();
            establishmentTypeList.Add("Casual Dining");
            establishmentTypeList.Add("Quick Bites");
            establishmentTypeList.Add("Dessert Parlor");
            establishmentTypeList.Add("Bakeries");
            establishmentTypeList.Add("Sweat Shops");
            establishmentTypeList.Add("Cafes");
            establishmentTypeList.Add("Food Courts");

            return establishmentTypeList;
        }

        public static List<string> GetCreditCards()
        {
            var creditCardList = new List<string>();
            creditCardList.Add("Visa");
            creditCardList.Add("Master");
            creditCardList.Add("American Express");
            creditCardList.Add("Nexus");

            return creditCardList;
        }

        public static List<string> GetAreas()
        {
            var areaList = new List<string>();
            areaList.Add("Banani");
            areaList.Add("Gulshan");
            areaList.Add("Gulshan");
            areaList.Add("Bashundhara");
            areaList.Add("Dhanmondi");
            areaList.Add("Uttara");
            areaList.Add("Baily");
            areaList.Add("Khilgaon");
            areaList.Add("Bashundhara");
            areaList.Add("Mirpur");
            areaList.Add("Mohammadpur");
            areaList.Add("Mothijheel");

            return areaList;
        }

        public static List<string> GetGoodForList()
        {
            var goodForList = new List<string>();

            goodForList.Add("Meetings");
            goodForList.Add("Families with children");
            goodForList.Add("Large groups");
            goodForList.Add("Local cuisine");
            goodForList.Add("Romantic");
            goodForList.Add("Gossip");
            goodForList.Add("Hangout");

            return goodForList;
        }

        public static List<string> GetParks()
        {
            var parkList = new List<string>();

            parkList.Add("Street");
            parkList.Add("Lot");
            parkList.Add("Garaze");

            return parkList;
        }

        public static List<string> GetAttires()
        {
            var attireList = new List<string>();

            attireList.Add("Casual");
            attireList.Add("Formal");

            return attireList;
        }
    }

    public class OptionsForDashBoard
    {
        public List<string> Cuisines { get; set; }
        public List<string> CreditCards { get; set; }
        public List<string> GoodFors { get; set; }
        public List<string> Attires { get; set; }
        public List<string> EstablishmentType { get; set; }
        public List<string> Area { get; set; }


        public OptionsForDashBoard()
        {
            Cuisines = ListOptions.GetCusines();
            CreditCards = ListOptions.GetCreditCards();
            GoodFors = ListOptions.GetGoodForList();
            Attires = ListOptions.GetAttires();
            EstablishmentType = ListOptions.GetEstablishmentTypes();
            Area = ListOptions.GetAreas();
        }
    }
}
