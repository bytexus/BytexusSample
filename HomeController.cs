using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ezalak.Models;
using ezalak.DBIntractionClasses;

namespace ezalak.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        WebAPIData WebAPIData_model = new WebAPIData();
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult News(int id=1)
        {
            NewsObject NewsObject = new NewsObject();
            ViewData["News"] = NewsObject= WebAPIData_model.GetNews(id, false);
            TempData["TotalPages"] = NewsObject.total_pages;
            TempData["ActivePageNumber"] = id;
            return View(); }
        public ActionResult NewsDetail(int id=0,int pagenumber=1)
        {
            ViewData["SingleNews"] = WebAPIData_model.GetSingleNews(id);
            //ViewData["SingleNews"] = (from l in WebAPIData_model.GetNews(pagenumber, false).newsfinallist where l.news_id== id select l).ToList();// WebAPIData_model.GetSingleNews(id);
            return View();

        }
    }
}
