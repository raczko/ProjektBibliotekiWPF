using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaWPFApp
{
    /// <summary>
    /// klasa dilioteki ktora dziedziczy dbContext czyli model bazy
    /// </summary>
    public class BibliotekaDb : DbContext
    {
        /// <summary>
        /// konstruktor dodajacy do Tabeli Categori dane jescli jest pusta
        /// </summary>
        public BibliotekaDb()
        {
            //utwozenie jezeli nie istnieje
            Database.EnsureCreated();

            if (!Categories.Any())
            {
                Categories.Add(new Category("Powieść"));
                Categories.Add(new Category("Kryminał"));
                Categories.Add(new Category("Historia"));
                Categories.Add(new Category("Nauka"));

                this.SaveChanges();
            }

            if (!Users.Any())
            {
                Users.Add(new User("admin", "admin1", "admin@admin.pl"));
                this.SaveChanges();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BibliotekaApp;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        /// <summary>
        /// Gettery i settery dla danych pozniej
        /// </summary>
        public DbSet<Book> Books { get; set; }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<User> Users { get; set; }
    }
}