using System;
using System.Collections.Generic;
using System.Text;

namespace ezalak.DBIntractionClasses
{

    public class Addslist
    {
        public string id { get; set; }
        public int adds_id { get; set; }
        public string adds_name { get; set; }
        public string adds_url { get; set; }
        public int adds_active_count { get; set; }
        public string adds_image { get; set; }
        public string adds_created_date { get; set; }
        public int active { get; set; }
        public object addslist { get; set; }
    }

    public class AddsObject
    {
        public string id { get; set; }
        public bool Status { get; set; }
        public string message { get; set; }
        public int total_Adds { get; set; }
        public List<Addslist> addslist { get; set; }
    }

}
