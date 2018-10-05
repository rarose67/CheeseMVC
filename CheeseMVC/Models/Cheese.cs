using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        private string name;
        private string description;

        public Cheese()
        {
            CheeseId = nextId;
            nextId++;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int CheeseId { get; private set; }
        public CheeseType Type { get; set; }
        private static int nextId = 1;

    }
}
