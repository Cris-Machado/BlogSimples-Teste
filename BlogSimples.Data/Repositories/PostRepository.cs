using BlogSimples.API.Domain.Interfaces.Repositories;
using BlogSimples.API.Domain.Services;
using Microsoft.Extensions.Logging;
using BlogSimples.API.Data.Interfaces;
using BlogSimples.API.Data.Repositories.Base;
using System.Text;

namespace BlogSimples.API.Data.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        private readonly ILogger<PostRepository> _logger;
        public PostRepository(IDbContext context, ILogger<PostRepository> logger) : base(context)
        {
            _logger = logger;
        }

        #region ## Methods
        //public async Task<IEnumerable<UserDto>> FindAllDtoAsync()
        //{
        //    var cn = Context.GetConnection();
        //    cn.Open();
        //    var result = await Task.Run(() => cn.Query<UserDto>(AllUserDto()).AsList());
        //    cn.Close();
        //    return result;
        //}
        #endregion

        #region ## Queries
        public static string AllUserDto()
        {
            var sql = new StringBuilder();

            sql.AppendLine("SELECT Users.Id,");
            sql.AppendLine("Users.Name,");
            sql.AppendLine("Users.Email,");
            sql.AppendLine("Users.PhoneNumber,");
            sql.AppendLine("FROM [Identity].AspNetUsers Users");

            return sql.ToString();
        }
        #endregion
    }
}
