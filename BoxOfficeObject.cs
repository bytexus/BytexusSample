using System;
using System.Collections.Generic;
using System.Text;

namespace ezalak.DBIntractionClasses
{
    class BoxOfficeData
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class TheatreList
    {
        public string id { get; set; }
        public string TheatreName { get; set; }
        public string ShowTimings { get; set; }
        public int status { get; set; }
    }

    public class MovieTheatrelist
    {
        public string id { get; set; }
        public string movie_name { get; set; }
        public List<TheatreList> theatre_list { get; set; }
    }

    public class BoxOfficeObject
    {
        public string id { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public int Total_Box { get; set; }
        public List<MovieTheatrelist> movieTheatrelist { get; set; }
    }
}
