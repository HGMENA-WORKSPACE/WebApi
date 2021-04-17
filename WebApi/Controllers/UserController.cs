namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApi.Contract;
    using WebApi.Dtos;

    /// <summary>
    /// Defines the <see cref="UserController" />.
    /// </summary>
    [Authorize(Roles = "1")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Defines the _iGenericRepository.
        /// </summary>
        private IGenericRepository<UserDto, RegisterDto> _iGenericRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="iGenericRepository">The iGenericRepository<see cref="IGenericRepository{UserDto, RegisterDto}"/>.</param>
        public UserController(IGenericRepository<UserDto, RegisterDto> iGenericRepository)
        {
            _iGenericRepository = iGenericRepository;
        }

        /// <summary>
        /// The GetUsers.
        /// </summary>
        /// <returns>The <see cref="Task{ActionResult{IEnumerable{UserDto}}}"/>.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers() => await _iGenericRepository.GetAllAsync();

        /// <summary>
        /// The GetUser.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UserDto}}"/>.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> GetUser(int id) => await _iGenericRepository.GetAsync(id);

        /// <summary>
        /// The PostUser.
        /// </summary>
        /// <param name="user">The user<see cref="UserDto"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UserDto}}"/>.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> RegisterUser(RegisterDto user) => await _iGenericRepository.InsertAsync(user);

        /// <summary>
        /// The PutUser.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="user">The user<see cref="UserDto"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UserDto}}"/>.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> PutUser(int id, [FromBody] RegisterDto user) => await _iGenericRepository.UpdateAsync(id, user);

        /// <summary>
        /// The DeleteUser.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{bool}}"/>.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteUser(int id) => await _iGenericRepository.DeleteAsync(id);
    }
}
