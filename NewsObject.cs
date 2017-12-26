using System;
using System.Collections.Generic;
using System.Text;

namespace ezalak.DBIntractionClasses
{
    public class Newsimageslist
    {
        public string id { get; set; }
        public int image_id { get; set; }
        public string image_path { get; set; }
        public string image_name { get; set; }
    }

    public class Newsfinallist
    {
        public string id { get; set; }
        public int news_id { get; set; }
        public string tittle { get; set; }
        public string content { get; set; }
        public string image { get; set; }
        public int active { get; set; }
        public DateTime newsdate { get; set; }
        public string duplicate_tittle { get; set; }
        public string duplicate_content { get; set; }
        public IList<Newsimageslist> newsimageslist { get; set; }
        public IList<Newsfinallist> news_list { get; set; }
    }

    public class NewsObject
    {
        public string id { get; set; }
        public bool Status { get; set; }
        public string message { get; set; }
        public int total_pages { get; set; }
        public int total_news { get; set; }
        public IList<Newsfinallist> newsfinallist { get; set; }
    }
}
