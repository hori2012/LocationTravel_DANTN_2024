using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationTravel
{
    internal class ModuleDistance
    {
        const double R = 6371; // Earth’s radius 
        public static double CalculateDistance_Haversine(ItemLoc loc1, ItemLoc loc2)
        {
            double dLat =ToRadians(loc1.Latitude - loc2.Latitude);
            double dLon =ToRadians(loc1.Longitude - loc2.Longitude);
            double lat1 = ToRadians(loc1.Latitude);
            double lat2 = ToRadians(loc2.Latitude);
            //fomula Haversine
            double a = Math.Pow(Math.Sin(dLat/2), 2) + Math.Cos(lat1)*Math.Cos(lat2)*Math.Pow(Math.Sin(dLon/2),2);
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

            return result;
        }
    }
}
