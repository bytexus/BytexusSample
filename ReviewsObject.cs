using System;
using System.Collections.Generic;
using System.Text;

namespace ezalak.DBIntractionClasses
{
    public class Movies
    {
        public string id { get; set; }
        public int movie_id { get; set; }
        public string Admin_review { get; set; }
        public string Total_star_rating { get; set; }
        public string created_date { get; set; }
        public string Movie_name { get; set; }
        public string image { get; set; }
        public string star_cast { get; set; }
        public string Directed_by { get; set; }
        public string Produced_by { get; set; }
        public int total_like { get; set; }
        public int total_dislike { get; set; }
        public int active { get; set; }
        public string duplicate_title { get; set; }
        public string duplicate_review { get; set; }
        public string story { get; set; }
        public string music_director { get; set; }
        public List<object> userreview { get; set; }
        public List<UserReview> USERREVIEWLIST { get; set; }
    }
    public class UserReview
    {
        public string id { get; set; }
        public int user_review_id { get; set; }
        public int user_review_movie_id { get; set; }
        public string movie_name { get; set; }
        public string user_id { get; set; }
        public string user_device_id { get; set; }
        public string user_display_name { get; set; }
        public string user_profile_pic { get; set; }
        public string user_review_title { get; set; }
        public string user_comments { get; set; }
        public double user_review_rating { get; set; }
        public int status { get; set; }
        public List<UserReview> userreviewlist { get; set; }
    }

    public class ReviewsObject
    {
        public string id { get; set; }
        public bool Status { get; set; }
        public string message { get; set; }
        public int total_pages { get; set; }
        public int total_movies { get; set; }
        public List<Movies> movieslist { get; set; }
        public List<UserReview> userreviewlist { get; set; }
    }
}
