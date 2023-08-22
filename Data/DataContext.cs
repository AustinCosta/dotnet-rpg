using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        //DbSet name is usually plural of entity name -- references the table in the database
        public DbSet<Character> Characters => Set<Character>(); //same as { get; set; }
    }
}