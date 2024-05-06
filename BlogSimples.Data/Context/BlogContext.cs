
using BlogSimples.API.Domain.Services;
using Microsoft.EntityFrameworkCore;
using BlogSimples.API.Data.Interfaces;
using System.Data.Common;
using Microsoft.Extensions.Configuration;

namespace BlogSimples.API.Data.Context
{
    public class BlogContext : DbContext, IDbContext
    {
        #region Ctor
#pragma warning disable CS8618
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
        }
        #endregion

        #region Methods
        public DbConnection GetConnection()
        {
            return Database.GetDbConnection();
        }
        #endregion

        #region DbSets
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts{ get; set; }
        #endregion

        #region Override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("AspNetUsers", "Identity");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .Build();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PostBlogDb;", x => x.MigrationsHistoryTable("__MigrationHistory", "Identity"));
        }
        #endregion
    }
}
