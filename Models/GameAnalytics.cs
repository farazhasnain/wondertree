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
        [ForeignKey("Users")]
        public string UserID { get; set; }//FK for Users ID
        public Users Users { get; set; }
    }
}