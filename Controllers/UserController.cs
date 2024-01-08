using AutoMapper;
using LaundroMat.Models;
using LaundroMat.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaundroMat.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(UserForCreationDTO userInput)
        {
            userInput.RegistrationDate = DateTime.UtcNow;
            Entities.User user = _mapper.Map<Entities.User>(userInput);
            _userRepository.AddUser(user);

            await _userRepository.SaveAsync();


            var userToReturn = _mapper.Map<UserDto>(user);
            return Ok(userToReturn);
        }

        [HttpGet("{id}", Name ="GetUser")]
        public async Task<ActionResult<UserDto>> GetUser(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("id is required");
            }
            var user = await _userRepository.GetUserAsync(id);
            var userToReturn = _mapper.Map<UserDto>(user);
            return Ok(userToReturn);
        }
    }
}
