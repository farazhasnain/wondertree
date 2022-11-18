using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WonderTree_API.Models
{
    public class GameAnalytics
    {
        public int id { get; set; }
        public DateTime Time { get; set; }
        public int Game_Metric_Score_1 { get; set; }
        public int Game_Metric_Score_2 { get; set; }
        public int EventType { get; set; } // 1= Event, 2 = Day, 3 = Week, 4 = Month, 5 = Year
        [ForeignKey("Users")]
        public string UserID { get; set; }//FK for Users ID
        public Users Users { get; set; }
    }
}