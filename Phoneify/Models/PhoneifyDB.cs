﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Phoneify.Models
{
    public class PhoneifyDB : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PhoneifyDB() : base("name=PhoneifyDB")
        {
        }

        public System.Data.Entity.DbSet<Phoneify.Models.Phone> Phones { get; set; }
    }

    public class PhoneifyDBInitializer : System.Data.Entity.DropCreateDatabaseAlways<PhoneifyDB>
    {
        protected override void Seed(PhoneifyDB context)
        {
            // TODO: Seed database with Phones
            
            base.Seed(context);
        }
    }

    public class ApplicationDBInitializer : System.Data.Entity.DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            // TODO: Seed database with Users
            base.Seed(context);
        }
    }
}
