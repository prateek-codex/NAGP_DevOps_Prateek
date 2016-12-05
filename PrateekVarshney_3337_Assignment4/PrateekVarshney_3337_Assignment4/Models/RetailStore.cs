using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PrateekVarshney_3337_Assignment4.Models
{
    public class RetailStore : DbContext
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public DbSet<Product> ProductList { get; set; }

        public RetailStore() : base("name=RetailManagement")
        { }
    }
}