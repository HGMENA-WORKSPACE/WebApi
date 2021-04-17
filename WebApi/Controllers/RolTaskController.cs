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
    /// Defines the <see cref="RolTaskController" />.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RolTaskController : ControllerBase
    {
        /// <summary>
        /// Defines the _rolTaskRepository.
        /// </summary>
        private IGenericRepository<RolTaskDto, RolTaskDto> _rolTaskRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolTaskController"/> class.
        /// </summary>
        /// <param name="rolTaskRepository">The rolTaskRepository<see cref="IGenericRepository{RolTaskDto}"/>.</param>
        public RolTaskController(IGenericRepository<RolTaskDto, RolTaskDto> rolTaskRepository)
        {
            _rolTaskRepository = rolTaskRepository;
        }

        /// <summary>
        /// The GetRolTask.
        /// </summary>
        /// <returns>The <see cref="Task{ActionResult{IEnumerable{RolTaskDto}}}"/>.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<RolTaskDto>>> GetRolTask() => await _rolTaskRepository.GetAllAsync();

        /// <summary>
        /// The GetUser.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{RolTaskDto}}"/>.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolTaskDto>> GetUser(int id) => await _rolTaskRepository.GetAsync(id);

        /// <summary>
        /// The PostUser.
        /// </summary>
        /// <param name="rolTask">The rolTask<see cref="RolTaskDto"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{RolTaskDto}}"/>.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolTaskDto>> PostUser(RolTaskDto rolTask) => await _rolTaskRepository.InsertAsync(rolTask);

        /// <summary>
        /// The PutUser.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="rolTask">The rolTask<see cref="RolTaskDto"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{RolTaskDto}}"/>.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolTaskDto>> PutUser(int id, [FromBody] RolTaskDto rolTask) => await _rolTaskRepository.UpdateAsync(id, rolTask);

        /// <summary>
        /// The DeleteUser.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{bool}}"/>.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteUser(int id) => await _rolTaskRepository.DeleteAsync(id);
    }
}
