using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Api.Controllers
{

    [Route("api/v1/[controller]/")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}
