
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using BlogSimples.API.Identity.Context;

namespace BlogSimples.API.Identity.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            var conn = "Server=(localdb)\\mssqllocaldb;Database=PostBlogDb;";

            var optionsBuilder = new DbContextOptionsBuilder<IdentityContext>();

            optionsBuilder.UseSqlServer(conn);
            return new IdentityContext(optionsBuilder.Options);
        }
    }
}
