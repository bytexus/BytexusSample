using System;
using System.Collections.Generic;
using System.Text;

namespace ezalak.DBIntractionClasses
{
    public class AlbumImageList
    {
        public string id { get; set; }
        public int image_id { get; set; }
        public string image_path { get; set; }
        public string image_name { get; set; }
        public string created_date { get; set; }
        public int status { get; set; }
        public int album_id { get; set; }
    }

    public class AlbumList
    {
        public string id { get; set; }
        public int gallery_id { get; set; }
        public string image_name { get; set; }
        public int album_id { get; set; }
        public string album_name { get; set; }
        public int active { get; set; }
        public string album_date { get; set; }
        public object gallerylist { get; set; }
        public List<AlbumImageList> Album_Image_List { get; set; }
        public AlbumList()
        {
            Album_Image_List = new List<AlbumImageList>();
        }
    }

    public class ImageObject
    {
        public string id { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
        public int Total_Album { get; set; }
        public int Total_Pages { get; set; }
        public List<AlbumList> Album_List { get; set; }
        public List<AlbumImageList> Album_Image_List { get; set; }
        public ImageObject()
        {
            Album_List = new List<AlbumList>();
            Album_Image_List = new List<AlbumImageList>();
        }
    }

}
