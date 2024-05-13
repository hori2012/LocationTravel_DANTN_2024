using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationTravel
{
    internal class ModuleCost
    {
        public static List<List<ItemLoc>> FindCombinations(List<ItemLoc> hotels, List<ItemLoc> foods, List<ItemLoc> entertains, List<ItemLoc> coffees, int numHotel, int numFood, int numEntertain, int numCoffee, decimal maxCost)
        {
            List<List<ItemLoc>> combinations = new List<List<ItemLoc>>();
            if (numHotel != 0)
            {
                hotels = hotels.OrderBy(h => h.Cost).ToList();
                foods = foods.OrderBy(h => h.Cost).ToList();
                entertains = entertains.OrderBy(h => h.Cost).ToList();
                coffees = coffees.OrderBy(h => h.Cost).ToList();
                List<List<ItemLoc>> hotelsCombination = GetCombinations(hotels, numHotel).OrderBy(x => Guid.NewGuid()).Take(20).ToList();
                List<List<ItemLoc>> foodsCombination = GetCombinations(foods, numFood).OrderBy(x => Guid.NewGuid()).Take(20).ToList();
                List<List<ItemLoc>> entertainCombination = GetCombinations(entertains, numEntertain).OrderBy(x => Guid.NewGuid()).Take(20).ToList();
                List<List<ItemLoc>> coffeesCombination = GetCombinations(coffees, numCoffee).OrderBy(x => Guid.NewGuid()).Take(20).ToList();
                foreach (var hotel in hotelsCombination)
                {
                    foreach (var food in foodsCombination)
                    {
                        foreach (var entertain in entertainCombination)
                        {
                            foreach (var coffee in coffeesCombination)
                            {
                                var combination = new List<ItemLoc>();
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
                foods = foods.OrderBy(h => h.Cost).ToList();
                entertains = entertains.OrderBy(h => h.Cost).ToList();
                coffees = coffees.OrderBy(h => h.Cost).ToList();
                List<List<ItemLoc>> foodsCombination = GetCombinations(foods, numFood).OrderBy(x => Guid.NewGuid()).Take(20).ToList();
                List<List<ItemLoc>> entertainCombination = GetCombinations(entertains, numEntertain).OrderBy(x => Guid.NewGuid()).Take(20).ToList();
                List<List<ItemLoc>> coffeesCombination = GetCombinations(coffees, numCoffee).OrderBy(x => Guid.NewGuid()).Take(20).ToList();
                foreach (var food in foodsCombination)
                {
                    foreach (var entertain in entertainCombination)
                    {
                        foreach (var coffee in coffeesCombination)
                        {
                            var combination = new List<ItemLoc>();
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
        public static List<List<ItemLoc>> GetCombinations(List<ItemLoc> list, int length)
        {
            var result = new List<List<ItemLoc>>();
            if (length == 1)
            {
                foreach (var item in list)
                {
                    result.Add(new List<ItemLoc> { item });
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
                        var combination = new List<ItemLoc> { list[i] };
                        combination.AddRange(values);
                        result.Add(combination);
                    }
                }
                return result;
            }
        }
    }
}
