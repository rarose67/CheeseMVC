using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models.Data
{
    public class CheeseData
    {
        private static List<Cheese> Cheeses = new List<Cheese>();

        public static void Add(Cheese cheese)
        {
            Cheeses.Add(cheese);
        }

        public static List<Cheese> findAll()
        {
            return Cheeses;
        }

        public static Cheese findById(int id)
        {
            return Cheeses.Find(x => x.CheeseId == id);
        }

        public static void deleteById(int[] cheeseIds)
        {
            foreach (int id in cheeseIds)
            {
                Cheeses.RemoveAll(x => x.CheeseId == id);
            }
        }

        public static void deleteById(int id)
        { 
            Cheeses.RemoveAll(x => x.CheeseId == id);
        }
    }
}
