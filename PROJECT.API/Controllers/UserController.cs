using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PROJECT.DTO.Security;
using PROJECT.IRepository.Infrastructure;
using PROJECT.IService.Interfaces.Security;
using PROJECT.Model.Security;

namespace PROJECT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;

        }

        // GET: api/User
        [Produces("application/json")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _userService.GetAllAsync();

                if (users == null)
                {
                    return BadRequest();
                }

                return Ok(users);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Exception in getting users: {ex.Message}"
                });
            }
        }

        // GET: api/User/Id
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {

                if (id == 0 || id < 0 || id > int.MaxValue || id < int.MinValue)
                {
                    return BadRequest();
                }

                var user = await _userService.GetByIdAsync(id);

                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Exception in getting user: {ex.Message}"
                });
            }

        }


        // POST: api/User
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserDTO userDto) 
        {
            try
            {
                if (userDto == null)
                {
                    return BadRequest();
                }

                if(userDto.Id > 0)
                {
                    return BadRequest();
                }

                // make a generic utility class to add created date, created by, modified date, modified by
                userDto.CreatedDate = DateTime.Now;
                var user = _mapper.Map<UserDTO, User>(userDto);

                if (!_userService.AddAsync(user))
                {
                    return BadRequest();
                }

                await _unitOfWork.CommitAsync();
                return Ok(user);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Exception in adding user: {ex.Message}"
                });
            }
        }


        // PUT: api/User
        [Produces("application/json")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserDTO userDto)
        {
            try
            {
                if (userDto == null)
                {
                    return BadRequest();
                }

                if (userDto.Id == 0 || userDto.Id < 0 || userDto.Id > int.MaxValue || userDto.Id < int.MinValue)
                {
                    return BadRequest();
                }

                var user = await _userService.GetByIdAsync(userDto.Id);

                if(user == null)
                {
                    return NotFound();
                }

                // make a generic utility class to add modified date, modified by
                userDto.ModifiedDate = DateTime.Now;
                user = _mapper.Map<UserDTO, User>(userDto);

                if (!_userService.UpdateAsync(user))
                {
                    return BadRequest();
                }

                await _unitOfWork.CommitAsync();
                return Ok(user);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Exception in updating user: {ex.Message}"
                });
            }
        }

        // DELETE: api/User/Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0 || id > int.MaxValue)
                {
                    return BadRequest("Invalid user ID.");
                }

                var user = await _userService.GetByIdAsync(id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }

                await _userService.DeleteAsync(user);

                var success = await _unitOfWork.CommitAsync();

                if (success <= 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to delete user." });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here)
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    message = $"Exception in deleting user: {ex.Message}"
                });
            }
        }

    }
}
