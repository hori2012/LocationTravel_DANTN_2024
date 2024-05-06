using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationTravel
{
    internal class ModuleCost
    {
        public static List<List<Item>> FindCombinations(List<Item> hotels, List<Item> foods, List<Item> entertains, List<Item> coffees, int numHotel, int numFood, int numEntertain, int numCoffee, decimal maxCost)
        {
            hotels = hotels.OrderBy(h => h.Cost).ToList();
            foods = foods.OrderBy(h => h.Cost).ToList();
            entertains = entertains.OrderBy(h => h.Cost).ToList();
            coffees = coffees.OrderBy(h => h.Cost).ToList();
            List<List<Item>> combinations = new List<List<Item>>();
            List<List<Item>> hotelsCombination = GetCombinations(hotels, 1).OrderBy(x => Guid.NewGuid()).Take(20).ToList();
            List<List<Item>> foodsCombination = GetCombinations(foods, numFood).OrderBy(x => Guid.NewGuid()).Take(20).ToList();
            List<List<Item>> entertainCombination = GetCombinations(entertains, numEntertain).OrderBy(x => Guid.NewGuid()).Take(20).ToList();
            List<List<Item>> coffeesCombination = GetCombinations(coffees, numEntertain).OrderBy(x => Guid.NewGuid()).Take(20).ToList();
            if (numHotel > 0)
            {
                foreach (var hotel in hotelsCombination)
                {
                    foreach (var food in foodsCombination)
                    {
                        foreach (var entertain in entertainCombination)
                        {
                            foreach (var coffee in coffeesCombination)
                            {
                                var combination = new List<Item>();
                                combination.AddRange(hotel);
                                combination.AddRange(food);
                                combination.AddRange(entertain);
                                combination.AddRange(coffee);

                                if (combination.Sum(item => item.Cost) <= maxCost)
                                {
                                    combinations.Add(combination);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (var food in foodsCombination)
                {
                    foreach (var entertain in entertainCombination)
                    {
                        foreach (var coffee in coffeesCombination)
                        {
                            var combination = new List<Item>();
                            combination.AddRange(food);
                            combination.AddRange(entertain);
                            combination.AddRange(coffee);

                            if (combination.Sum(item => item.Cost) <= maxCost)
                            {
                                combinations.Add(combination);
                            }
                        }
                    }
                }
            }
            return combinations;
        }
        public static List<List<Item>> GetCombinations(List<Item> list, int length)
        {
            var result = new List<List<Item>>();
            if (length == 1)
            {
                foreach (var item in list)
                {
                    result.Add(new List<Item> { item });
                }
                return result;
            }
            else
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var smallerCombinations = GetCombinations(list.Skip(i + 1).ToList(), length - 1);
                    foreach (var values in smallerCombinations)
                    {
                        var combination = new List<Item> { list[i] };
                        combination.AddRange(values);
                        result.Add(combination);
                    }
                }
                return result;
            }
        }
    }
    class Item
    {
        public int Id { get; set; }
        public decimal Cost { get; set; }

    }
}
