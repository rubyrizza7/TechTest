using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TechTest
{
    public class CombinationsContext : DbContext
    {
        public string DbPath { get; private set; }
        public DbSet<Result> Results { get; set; }

        // for not in memory
        /*
        public CombinationsContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}combinations.db";
        }
        
         protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");*/

        // for in memory
        public CombinationsContext(DbContextOptions<CombinationsContext> options)
        : base(options)
        { }

       

        

    }
}
