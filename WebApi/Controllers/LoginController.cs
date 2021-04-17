namespace WebApi.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebApi.Contract;
    using WebApi.Dtos;

    /// <summary>
    /// Defines the <see cref="LoginController" />.
    /// </summary>
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Defines the _iLoginRepository.
        /// </summary>
        private ILoginRepository<UserDto> _iLoginRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginController"/> class.
        /// </summary>
        /// <param name="iLoginRepository">The iLoginRepository<see cref="ILoginRepository{UserDto}"/>.</param>
        public LoginController(ILoginRepository<UserDto> iLoginRepository)
        {
            _iLoginRepository = iLoginRepository;
        }

        /// <summary>
        /// The RegisterUser.
        /// </summary>
        /// <param name="user">The user<see cref="RegisterDto"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{UserDto}}"/>.</returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> RegisterUser(RegisterDto user) => await _iLoginRepository.GetUser(user);

        [HttpPost("token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> GetToken(RegisterDto user) => await _iLoginRepository.GetToken(user);

    }
}
