using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace koi_jabo_model_changer
{
    class Program
    {
        static void Main(string[] args)
        {
            RestaurantStore store = new RestaurantStore();

            var result = store.Search();

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
