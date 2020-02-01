using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealComm
{
    public class Country
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
    }

    public class AdministrativeArea
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
    }

    public class City
    {
        [JsonIgnore]
        public int Version { get; set; }
        
        public string Key { get; set; }
        [JsonIgnore]
        public string Type { get; set; }
        [JsonIgnore]
        public int Rank { get; set; }
        
        public string LocalizedName { get; set; }
        [JsonIgnore]
        public Country Country { get; set; }
        [JsonIgnore] 
        public AdministrativeArea AdministrativeArea { get; set; }
    }
}