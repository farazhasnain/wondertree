using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WonderTree_API.Models;

namespace WonderTree_API.App_Start
{
    public class SqlContext : DbContext
    {
        public SqlContext() :base("test")
        {

        }
        public DbSet<GameAnalytics> gameAnalytics { get; set; }
        public DbSet<Users> users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}