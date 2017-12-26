using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using ezalak.DBIntractionClasses;
using Newtonsoft.Json;
using System.Text;

namespace ezalak.Models
{
    public class WebAPIData
    {
        public static int curPage;
        public static int totalPages;
        public static NewsObject mNewsObject;
        public static List<Showbiz> products;
        public static string last_sync = "";
        public static bool IsSearching;
        public static bool IsRefresh;
        public static string keyword;

        public NewsObject GetNews(int pageNo, bool _IsRefresh)
        {
            IsSearching = false;
            string sync_time = DateTime.Now.ToString("HH:mm:ss");
            NameValueCollection paramCollection = new NameValueCollection();
            paramCollection.Add("newsdate", DateTime.Now.ToString("dd/MM/yyyy"));
            paramCollection.Add("page_size", _IsRefresh ? "20" : "6");
            paramCollection.Add("page_number", pageNo.ToString());
            if (_IsRefresh && pageNo == 1)
                paramCollection.Add("last_sync", last_sync);
            Result result = Global.GetData(Constant.NewsAPI, paramCollection);
            NewsObject news = new NewsObject();
            if (result.ResultCode)
            {
                news = JsonConvert.DeserializeObject<NewsObject>(result.ResultValue);
                if (news.Status)
                {
                    mNewsObject = new NewsObject();
                    mNewsObject.id = news.id;
                    mNewsObject.message = news.message;
                    mNewsObject.Status = news.Status;
                    mNewsObject.total_news = news.total_news;
                    mNewsObject.total_pages = news.total_pages;
                    mNewsObject.newsfinallist = new List<Newsfinallist>();
                    foreach (var item in news.newsfinallist)
                    {
                        if (!string.IsNullOrEmpty(item.content))
                        {
                            byte[] data = Encoding.Default.GetBytes(item.content);
                            item.content = Encoding.UTF8.GetString(data);
                        }
                        if (!string.IsNullOrEmpty(item.content))
                        {
                            byte[] data = Encoding.Default.GetBytes(item.tittle);
                            item.tittle = Encoding.UTF8.GetString(data);
                        }
                        last_sync = sync_time;
                        if (!IsRefresh)
                        {
                            if (item.active == 1)
                            {
                                mNewsObject.newsfinallist.Add(item);
                            }
                        }
                        else
                        {
                            if (item.active == 1)
                            {
                                if (mNewsObject.newsfinallist.Where(l => l.tittle == item.tittle).ToList().Count == 0) { mNewsObject.newsfinallist.Add(item); }
                            }
                            else
                            {
                                if (mNewsObject.newsfinallist.Where(l => l.tittle == item.tittle).ToList().Count > 0) { mNewsObject.newsfinallist.Remove(item); }
                            }
                        }
                    }
                }
            }
            products = new List<Showbiz>();
            foreach (var item in mNewsObject.newsfinallist)
            {
                string url = "";
                if (item.newsimageslist.Count > 0)
                    url = String.IsNullOrEmpty(item.newsimageslist[0].image_path) ? "" : item.newsimageslist[0].image_path;
                Showbiz ObjShowbiz = new Showbiz(item.news_id, url, item.tittle, item.content, 10642, 1599);
                products.Add(ObjShowbiz);
            }
            curPage = pageNo;
            return news;
        }

        public Newsfinallist GetSingleNews(int newsId)
        {
            IsSearching = false;
            string sync_time = DateTime.Now.ToString("HH:mm:ss");
            NameValueCollection paramCollection = new NameValueCollection();
            paramCollection.Add("news_id", newsId.ToString());
            Result result = Global.GetData(Constant.SingleNews, paramCollection);
            Newsfinallist Singlenews = new Newsfinallist();
            if (result.ResultCode)
            {
                Singlenews = JsonConvert.DeserializeObject<Newsfinallist>(result.ResultValue);
                if (!string.IsNullOrEmpty(Singlenews.content))
                {
                    byte[] data = Encoding.Default.GetBytes(Singlenews.content);
                    Singlenews.content = Encoding.UTF8.GetString(data);
                }
                if (!string.IsNullOrEmpty(Singlenews.content))
                {
                    byte[] data = Encoding.Default.GetBytes(Singlenews.tittle);
                    Singlenews.tittle = Encoding.UTF8.GetString(data);
                }
            }
            return Singlenews;
        }

        public void GetSearchedNews(int pageNo, string _keyword)
        {
            curPage = pageNo;
            IsSearching = true;
            products = new List<Showbiz>();
            NameValueCollection paramCollection = new NameValueCollection();
            paramCollection.Add("str_keyword", _keyword);
            paramCollection.Add("page_size", "10");
            paramCollection.Add("page_number", pageNo.ToString());
            Result result = Global.GetData(Constant.NewsSearchAPI, paramCollection);
            NewsObject news = new NewsObject();
            if (result.ResultCode)
            {
                news = JsonConvert.DeserializeObject<NewsObject>(result.ResultValue);
                if (news.Status)
                {
                    foreach (var item in news.newsfinallist)
                    {
                        string url = "";
                        if (item.newsimageslist.Count > 0)
                            url = String.IsNullOrEmpty(item.newsimageslist[0].image_path) ? "" : item.newsimageslist[0].image_path;
                        Showbiz ObjShowbiz = new Showbiz(item.news_id, url, item.tittle, item.content, 1042, 599);
                        if (item.active == 1)
                            products.Add(ObjShowbiz);
                    }
                }
            }
        }

    }

    public class Showbiz
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Title { get; set; }
        public string ShowbizDescription { get; set; }
        public int LikeCount { get; set; }
        public int ShareCount { get; set; }
        public Showbiz(int id, string photoUrl, string title, string showbizDescription, int likeCount, int shareCount)
        {
            Id = id;
            PhotoUrl = photoUrl;
            Title = title;
            ShowbizDescription = showbizDescription;
            LikeCount = likeCount;
            ShareCount = shareCount;
        }
    }
}