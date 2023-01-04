using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ders54_Core_Empty.Models
{
    public class iakademi45Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:iakademi45connection"]);
        }

        public DbSet<Student> Students { get; set; }
    }
}
