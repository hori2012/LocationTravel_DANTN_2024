using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LocationTravel
{
    internal class ModuleDistance
    {
        const double R = 6371; // Earth’s radius 
        const string BingKey = "2l1NGkhCrivYeFEnlbza~_M8py2jyFINioFJpwtSDeA~AtLJe7rpNkl9EypW9K2nmWAlEp7TEaWInCfVlITyJtqrY4UdqnIZgLNe_O736GUZ"; //Your Bing Map Key
        static readonly HttpClient client = new HttpClient();
        public static double CalculateDistance_Haversine(ItemLoc loc1, ItemLoc loc2)
        {
            double dLat = ToRadians(loc1.Latitude - loc2.Latitude);
            double dLon = ToRadians(loc1.Longitude - loc2.Longitude);
            double lat1 = ToRadians(loc1.Latitude);
            double lat2 = ToRadians(loc2.Latitude);
            //fomula Haversine
            double a = Math.Pow(Math.Sin(dLat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dLon / 2), 2);
            double c = 2 * Math.Asin(Math.Sqrt(a));
            return Math.Round(R * c, 2);
        }

        public static double ToRadians(double numb)
        {
            return numb * (Math.PI / 180.0);
        }
        public static List<List<ItemLoc>> CombinationFilter(List<List<ItemLoc>> combinations, double maxDistance)
        {
            List<List<ItemLoc>> result = new List<List<ItemLoc>>();
            bool isValid;
            foreach (var item in combinations)
            {
                isValid = true;
                for (int i = 0; i < item.Count; i++)
                {
                    for (int j = i + 1; j < item.Count; j++)
                    {
                        if (CalculateDistance_Haversine(item[i], item[j]) > maxDistance)
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid == false)
                    {
                        break;
                    }
                }
                if (isValid == true)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static double[,] GenerateMatrix(int numRow_Col, string responseBody)
        {
            double[,] matrix = new double[numRow_Col, numRow_Col];

            return matrix;
        }
        public static async Task<string> ConnectionApi(List<ItemLoc> locations)
        {
            string origins = string.Join(";", locations.Select(loc => $"{loc.Latitude},{loc.Longitude}"));
            string destinations = origins; // Assuming you want a distance matrix between all locations
            string requestUri = $"https://dev.virtualearth.net/REST/v1/Routes/DistanceMatrix?origins={origins}&destinations={destinations}&travelMode=driving&key={BingKey}";
            HttpResponseMessage response = await client.GetAsync(requestUri);
            string responseBody = "";
            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
            return responseBody;
        }
    }
}
