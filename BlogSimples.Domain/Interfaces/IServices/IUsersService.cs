using BlogSimples.API.Domain.Services;


namespace BlogSimples.API.Domain.Interfaces.Repositories
{
    public interface IUsersService : IServiceBase<User>
    {
        string Calculo();
    }
}
