using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationTravel
{
    internal class DistanceMatrix
    {
        public string AuthenticationResultCode { get; set; }
        public string BrandLogoUri { get; set; }
        public string Copyright { get; set; }
        public List<ResourceSet> ResourceSets { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string TraceId { get; set; }
    }

    public class ResourceSet
    {
        public int EstimatedTotal { get; set; }
        public List<Resource> Resources { get; set; }
    }

    public class Resource
    {
        public string __Type { get; set; }
        public List<Item> Destinations { get; set; }
        public List<Item> Origins { get; set; }
        public List<Result> Results { get; set; }
    }

    public class Item
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class Result
    {
        public int DestinationIndex { get; set; }
        public int OriginIndex { get; set; }
        public int TotalWalkDuration { get; set; }
        public double TravelDistance { get; set; }
        public double TravelDuration { get; set; }
    }

}
