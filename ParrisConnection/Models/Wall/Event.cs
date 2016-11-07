using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ParrisConnection.Models.Wall
{
    public class Event
    {
        public Event()
        {
            
        }
        [JsonProperty]
        public int Id { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        [JsonProperty]
        [StringLength(255)]
        public string Description { get; set; }
        [JsonProperty]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime DateTime { get; set; }
    }
}