using System;

namespace Converter_json_to_csv
{
    public class Goods
    {
        public string Name{ get;set;}
        public int Price { get; set; }
        public int Amount { get; set; }
            
        public Goods(string name, int price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }
    }
}