using System;
using System.Collections.Generic;
using System.Text;

namespace ezalak.DBIntractionClasses
{

    public class Videolist
    {
        public string id { get; set; }
        public int gallery_video_id { get; set; }
        public string gallery_video_name { get; set; }
        public string gallery_video_url { get; set; }
        public string created_date { get; set; }
        public int active { get; set; }
        public List<Videolist> galleryvideolist { get; set; }
        public Videolist()
        {
            galleryvideolist = new List<Videolist>();
        }
    }

    public class VideoObject
    {
        public string id { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public int Total_Video { get; set; }
        public int Total_Pages { get; set; }
        public List<Videolist> videolist { get; set; }
        public VideoObject()
        {
            videolist = new List<Videolist>();
        }
    }
}
