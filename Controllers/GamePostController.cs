using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WonderTree_API.App_Start;
using WonderTree_API.Models;
using System.Data.Entity;
using Newtonsoft.Json;

namespace WonderTree_API.Controllers
{
    public class GamePostController : Controller
    {
        private SqlContext db = new SqlContext();

        // GET: GameAnalytics
        public ActionResult Index()
        {
            var gameAnalytics = db.gameAnalytics.Include(g => g.Users);
            return View(gameAnalytics.ToList());
        }
        [System.Web.Http.HttpPost]
        public async Task<bool> AddAnalytics([FromBody] GameAnalytics model)
        {
            if (ModelState.IsValid)
            {
                db.gameAnalytics.Add(model);
                db.SaveChanges();
                var mongo = new MongoService();
                mongo.Insert(model);
                return true;
            }
            return false;
        }
        [System.Web.Mvc.HttpPost]
        public async Task<bool> AddUser([FromBody] Users model)
        {
            if (ModelState.IsValid)
            {
                model.UserID = Guid.NewGuid().ToString();
                db.users.Add(model);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        [System.Web.Mvc.HttpGet]
        public async Task<string> GetAll()
        {
            var service = new MongoService();
            var resp = JsonConvert.SerializeObject(service.GetAll());
            return resp;
        }
        [System.Web.Mvc.HttpGet]
        public async Task<string> GetByUserId(string userid)
        {
            var service = new MongoService();
            var resp = JsonConvert.SerializeObject(service.GetByUserId(userid));
            return resp;
        }
        [System.Web.Mvc.HttpGet]
        public async Task<string> GetByDate(DateTime toDate,DateTime fromDate)
        {
            var service = new MongoService();
            var resp = JsonConvert.SerializeObject(service.GetByDate(toDate,fromDate));
            return resp;
        }
        [System.Web.Mvc.HttpGet]
        public async Task<string> GetByEventType(int eventType)
        {
            var service = new MongoService();
            var resp = JsonConvert.SerializeObject(service.GetByEventType(eventType));
            return resp;
        }
    }
}