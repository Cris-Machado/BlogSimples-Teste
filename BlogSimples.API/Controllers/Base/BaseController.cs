
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogSimples.API.Presentation.Controllers.Base
{

    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        #region Ctor
        public BaseController()
        {
        }
        #endregion

    }
}
