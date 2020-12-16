using System;
using System.Collections.Generic;
using System.Text;

namespace LabXamMarc.Model
{
    public class Data
    {
        public int id { get; set; }
        public DateTime pubdate_iso8601 { get; set; }
        public string pubdate_unix { get; set; }
        public string title_type { get; set; }
        public string title_location { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public string content_formatted { get; set; }
        public string content_teaser { get; set; }
        public string location_string { get; set; }
        public string date_human { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string viewport_northeast_lat { get; set; }
        public string viewport_northeast_lng { get; set; }
        public string viewport_southwest_lat { get; set; }
        public string viewport_southwest_lng { get; set; }
        public string administrative_area_level_1 { get; set; }
        public object administrative_area_level_2 { get; set; }
        public string image { get; set; }
        public string external_source_link { get; set; }
        public string permalink { get; set; }
    }
}
