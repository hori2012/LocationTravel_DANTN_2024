using LocationTravel.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        /// <summary>
        /// Fomula Haversine 
        /// </summary>
        /// <returns></returns>
        public static double CalculateDistance_Haversine(ItemLoc loc1, ItemLoc loc2)
        {
            double dLat = ToRadians(loc1.Latitude - loc2.Latitude);
            double dLon = ToRadians(loc1.Longitude - loc2.Longitude);
            double lat1 = ToRadians(loc1.Latitude);
            double lat2 = ToRadians(loc2.Latitude);
            //Apply Haversine Formula
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
        /// <summary>
        /// Bing maps API - Get matrix distance between location
        /// </summary>
        /// <returns></returns>
        public static async Task<double[,]> ConnectionAPI_DisatanceMatrix(List<ItemLoc> locations)
        {
            string origins = string.Join(";", locations.Select(loc => $"{loc.Latitude},{loc.Longitude}"));
            Debug.WriteLine(origins);
            string destinations = origins; // Assuming you want a distance matrix between all locations
            string requestUri = $"https://dev.virtualearth.net/REST/v1/Routes/DistanceMatrix?origins={origins}&destinations={destinations}&travelMode=driving&key={BingKey}";
            HttpResponseMessage response = await client.GetAsync(requestUri);
            string responseBody = "";
            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
                DistanceMatrix distanceMatrix = JsonConvert.DeserializeObject<DistanceMatrix>(responseBody);
                double[,] matrix = new double[locations.Count, locations.Count];
                if (distanceMatrix != null)
                {
                    foreach (var resourceset in distanceMatrix.ResourceSets)
                    {
                        foreach (var resource in resourceset.Resources)
                        {
                            for (int i = 0; i < locations.Count; i++)
                            {
                                int j = 0;
                                foreach (var result in resource.Results.Where(x => x.OriginIndex == i).ToList())
                                {
                                    matrix[i, j] = result.TravelDistance;
                                    j++;
                                }
                            }
                        }
                    }
                }
                else
                {
                    Debug.WriteLine("Data connect API return --> NULL");
                }
                return matrix;
            }
            else
            {
                Debug.WriteLine($"Error: {response.StatusCode}");
            }
            return null;
        }
        /// <summary>
        /// Handle shortest path finding -- TSP.
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ItemLoc>> GetLocations_AntAlgorithm(List<ItemLoc> locations)
        {
            int[] item = new int[locations.Count];
            double[,] matrix = await ConnectionAPI_DisatanceMatrix(locations);
            item = AntAlgorithm.Ant_ACO(matrix);
            List<ItemLoc> result = new List<ItemLoc>();
            for (int k = 0; k < item.Length; k++)
            {
                result.Add(locations[k]);
            }
            double d = 0;
            Debug.WriteLine("Khoang cach giua cac dia diem:");
            for (int i = 1; i < item.Length; i++)
            {
                Debug.WriteLine("\tKhoang cach tu {0} -> {1}: {2} Km", item[i - 1], item[i], matrix[item[i - 1], item[i]]);
                d += matrix[item[i - 1], item[i]];
            }
            Debug.WriteLine("\tKhoang cach tu {0} -> {1}: {2} Km", item[item.Length - 1], item[0], matrix[item[item.Length - 1], item[0]]);
            d += matrix[item[item.Length - 1], item[0]];
            Debug.WriteLine("\t-> Tong quang duong di chuyen la: {0}", d);
            return result;
        }
    }
}
