

using BlogSimples.API.Domain.Interfaces.Base;
using BlogSimples.API.Domain.Interfaces.Repositories;
using BlogSimples.API.Domain.Services;

namespace BlogSimples.API.Domain.Interfaces.Services
{
    public class UsersService : ServiceBase<User>, IUsersService
    {
        public UsersService(IUnitOfWork unitOfWork, IRepositoryBase<User> repository) : base(unitOfWork, repository)
        {
        }

        #region Methods
        public string Calculo()
        {
            return "teste";
        }
        #endregion
    }
}
