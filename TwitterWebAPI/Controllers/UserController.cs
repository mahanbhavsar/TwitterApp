using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterWebAPI.Models;
using TwitterWebAPI.Services;
using TwitterWebAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TwitterWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }        

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<UserViewModel> Post([FromBody] User user)
        {
            var registeredUser = _userRepository.RegisterUser(user);
            return this.Ok(_mapper.Map<UserViewModel>(registeredUser));
        }

        // PUT api/<UserController>/5
        [HttpPut]
        [Authorize]
        public IActionResult ResetPassword([FromBody] User user)
        {
            var userName = Request.HttpContext.User.Identity?.Name;
            if(userName == null)
            {
                return NotFound("User not found");
            }
            return this.Ok(_userRepository.ResetPassword(user, userName));
        }
    }
}
