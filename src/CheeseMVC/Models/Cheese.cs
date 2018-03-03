using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        //Fields
        private static int nextId = 1;

        public int CheeseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        //Constructors - only need a default constructor, necessary for model binding
        public Cheese ()
        {
            CheeseId = nextId;
            nextId++;
        }


    }
}
