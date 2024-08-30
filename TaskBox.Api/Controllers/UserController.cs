using Microsoft.AspNetCore.Mvc;
using TaskBox.Api.Controllers.Base;
using TaskBox.Application.DTOs;
using TaskBox.Application.Interfaces;

namespace TaskBox.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : BaseController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserAppService _userAppService;

        public UserController(ILogger<UserController> logger, IUserAppService userAppService)
        {
            _logger = logger;
            _userAppService = userAppService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            try
            {
                var result = await _userAppService.GetAll();
                return ResponseGet(result);
            }
            catch (Exception ex)
            {
                return ResponseBadRequest();
            }
        }
    }
}
