using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BlogSimples.API.Domain.Interfaces.Repositories;
using BlogSimples.API.Identity.Dtos;
using BlogSimples.API.Identity.Entitites;
using BlogSimples.API.Presentation.Controllers.Base;
using System.Security.Claims;

namespace BlogSimples.API.Presentation.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUsersService _userService;
        private readonly UserManager<AppUser> _userManager;

        public UsersController(IUsersService userService, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        #region Methods

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> InsertUser(User model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
                return BadRequest("Já existe um usuário cadastrado para esse e-mail, favor especificar um novo endereço de e-mail.");

            user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return BadRequest("Ocorreu um erro ao cadastrar o usuário, tente novamente.");

            return Ok(user.Id);
        }
        #endregion
    }
}
