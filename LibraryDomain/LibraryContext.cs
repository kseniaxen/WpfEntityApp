using LibraryDomain.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDomain
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>()
                .Property(e => e.PublisherName).HasMaxLength(50);
            modelBuilder.Entity<Publisher>()
                .Property(e => e.Address).HasMaxLength(100);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Book> Books { get; set; }
    }
}
