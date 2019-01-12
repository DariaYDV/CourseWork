using ComputersDBCW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ComputersDBCW.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var computers = new List<Computers>()
            {
                new Computers {Index = 0, Model = "Asus", Price = 13800.90, CPU = "Intel", RAM = 8 },
                new Computers {Index = 1, Model = "Asus", Price = 15734.00, CPU = "Intel", RAM = 8 },
                new Computers {Index = 2, Model = "Asus", Price = 13455.00, CPU = "Intel", RAM = 8 },
                new Computers {Index = 0, Model = "Acer", Price = 10500.00, CPU = "Intel", RAM = 4 },
                new Computers {Index = 1, Model = "Dell", Price = 9800.40, CPU = "Intel", RAM = 2 },
                new Computers {Index = 2, Model = "Vinga", Price = 21800.00, CPU = "AMD", RAM = 8 }
            };
            computers.ForEach(x => context.Computers.Add(x));
            context.SaveChanges();
        }
    }
}