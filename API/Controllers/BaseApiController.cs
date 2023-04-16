using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // [controller] is a placeholder ===> Users
    public class BaseApiController : ControllerBase
    {
    }
}
