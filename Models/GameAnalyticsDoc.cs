using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WonderTree_API.Models
{
    public class GameAnalyticsDoc
    {
        [BsonId]
        public ObjectId docId { get; set; }
        public GameAnalytics GameAnalytics { get; set; }
    }
}