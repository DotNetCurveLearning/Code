using Microsoft.EntityFrameworkCore;
using System.Text;
using static System.Console;

namespace Packt.Shared
{
    /// <summary>
    /// This class is used to manages the connection to the database.
    /// </summary>
    public class Northwind : DbContext
    {
        /// <summary>
        /// These two properties map to tables in the database.
        /// </summary>
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
        
        /// <summary>
        /// This method checks the provider filed to either
        /// use SQLite or SQL server
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // calling an extension method to use lazy loading proxies
            optionsBuilder.UseLazyLoadingProxies(); 

            if (ProjectConstants.DatabaseProvider.Equals("SQLite"))
            {
                string path = Path.Combine(Environment.CurrentDirectory, "Northwind.db");

                WriteLine($"Using {path} database file.");
                optionsBuilder.UseSqlite($"Filename={path}");
            }
            else
            {
                StringBuilder connectionString = new();
                connectionString.Append("Data Source=.;")
                    .Append("Initial Catalog=Northwind;")
                    .Append("Integrated Security=true;")
                    .Append("MultipleActiveResultSets=true");

                optionsBuilder.UseSqlServer(connectionString.ToString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // example of using Fluent API instead of attributes
            // to limit the length of a category name to 15
            modelBuilder.Entity<Category>()
                .Property(category => category.CategoryName)
                .IsRequired()       // NOT NULL
                .HasMaxLength(15);

            if (ProjectConstants.DatabaseProvider == "SQLite")
            {
                // added to "fix" the lack of decimal support in SQLite
                modelBuilder.Entity<Product>()
                    .Property(product => product.Cost)
                    .HasConversion<double>();
            }
        }
    }
}
