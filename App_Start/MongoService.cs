using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WonderTree_API.Models;

namespace WonderTree_API.App_Start
{
    public class MongoService
    {
        private readonly string MongoUsername = ConfigurationManager.AppSettings["MongoUsername"];
        private readonly string MongoPassword = ConfigurationManager.AppSettings["MongoPassword"];
        //var MongoPort = ConfigurationManager.AppSettings["MongoPort"];  //27017
        private readonly string MongoHost = ConfigurationManager.AppSettings["MongoHost"];  //local
        public bool Insert(GameAnalytics model)
        {
            string conString = $"mongodb://{MongoHost}&w=majority";
            var client = new MongoClient(
                conString

            );
            var database = client.GetDatabase("test");
            var temp = database.GetCollection<GameAnalyticsDoc>("GameAnalytics");
            var mod = new GameAnalyticsDoc() { GameAnalytics = model };
            temp.InsertOne(mod);
            return true;
        }
        public List<GameAnalyticsDoc> GetAll()
        {
            string conString = $"mongodb://{MongoHost}&w=majority";
            var client = new MongoClient(
                conString

            );
            var database = client.GetDatabase("test");
            var temp = database.GetCollection<GameAnalyticsDoc>("GameAnalytics");
            var resp = temp.Find(x => x.docId != null).ToList();
            return resp;
        }
        public List<GameAnalyticsDoc> GetByUserId(string userIds)
        {
            string conString = $"mongodb://{MongoHost}&w=majority";
            var client = new MongoClient(
                conString

            );
            var database = client.GetDatabase("test");
            var temp = database.GetCollection<GameAnalyticsDoc>("GameAnalytics");
            return temp.Find(x => x.GameAnalytics.UserID == userIds).ToList();
        }
        public List<GameAnalyticsDoc> GetByDate(DateTime toDate,DateTime fromDate)
        {
            string conString = $"mongodb://{MongoHost}&w=majority";
            var client = new MongoClient(
                conString

            );
            var database = client.GetDatabase("test");
            var temp = database.GetCollection<GameAnalyticsDoc>("GameAnalytics");
            return temp.Find(x => x.GameAnalytics.Time >= toDate && x.GameAnalytics.Time < fromDate).ToList();
        }
    }
}