namespace RealComm.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Weather")]
    public partial class Weather
    {
        public int Id { get; set; }

        [Required]
        [StringLength(90)]
        public string WeatherText { get; set; }

        public double Temp { get; set; }

        [Required]
        [StringLength(30)]
        public string CityCode { get; set; }
        [JsonIgnore]
        public DateTime? lastCall { get; set; }
    }
}
