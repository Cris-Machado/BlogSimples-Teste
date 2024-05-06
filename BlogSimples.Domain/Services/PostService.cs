

using BlogSimples.API.Domain.Interfaces.Base;
using BlogSimples.API.Domain.Interfaces.Repositories;
using BlogSimples.API.Domain.Services;

namespace BlogSimples.API.Domain.Interfaces.Services
{
    public class PostService : ServiceBase<Post>, IPostService
    {
        public PostService(IUnitOfWork unitOfWork, IRepositoryBase<Post> repository) : base(unitOfWork, repository)
        {
        }
    }
}
