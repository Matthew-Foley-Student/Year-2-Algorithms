using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyLibrary.Model
{
    public class ItemModel
    {
        public ItemModel(string name, int price, int weight, int amount)
        {
            Name = name;
            Price = price;
            Weight = weight;
            Amount = amount;
        }

        public string Name { get; set; }
        public int Price { get; set; }
        public int Weight { get; set; }   
        public int Amount { get; set; }
        
        public ItemModel() { }
    }


    }
