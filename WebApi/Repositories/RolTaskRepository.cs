namespace WebApi.Repositories
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApi.Contract;
    using WebApi.Dtos;

    /// <summary>
    /// Defines the <see cref="RolTaskRepository" />.
    /// </summary>
    public class RolTaskRepository : IGenericRepository<RolTaskDto, RolTaskDto>
    {
        /// <summary>
        /// Defines the _context.
        /// </summary>
        private readonly ContextDB _context;

        /// <summary>
        /// Defines the _mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Defines the _dbset.
        /// </summary>
        private DbSet<RolTaskModel> _dbset;

        /// <summary>
        /// Initializes a new instance of the <see cref="RolTaskRepository"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="ContextDB"/>.</param>
        /// <param name="mapper">The mapper<see cref="IMapper"/>.</param>
        public RolTaskRepository(
            ContextDB context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
            _dbset = context.Set<RolTaskModel>();
        }

        /// <summary>
        /// The GetAllAsync.
        /// </summary>
        /// <returns>The <see cref="Task{List{RolTaskDto}}"/>.</returns>
        public async Task<List<RolTaskDto>> GetAllAsync()
        {
            try
            {
                var users = await _dbset.ToListAsync();
                return _mapper.Map<List<RolTaskDto>>(users);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The GetAsync.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{RolTaskDto}"/>.</returns>
        public async Task<RolTaskDto> GetAsync(int id)
        {
            try
            {
                var rolTaskDto = await _dbset.SingleOrDefaultAsync(x => x.Id == id);
                return _mapper.Map<RolTaskDto>(rolTaskDto);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The AddAsync.
        /// </summary>
        /// <param name="rolTaskDto">The rolTaskDto<see cref="RolTaskDto"/>.</param>
        /// <returns>The <see cref="Task{RolTaskDto}"/>.</returns>
        public async Task<RolTaskDto> InsertAsync(RolTaskDto rolTaskDto)
        {
            RolTaskModel rolTask = _mapper.Map<RolTaskModel>(rolTaskDto);
            rolTask.Guid = Guid.NewGuid().ToString();
            _dbset.Add(rolTask);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<RolTaskDto>(rolTask);
        }

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="rolTaskDto">The rolTaskDto<see cref="RolTaskDto"/>.</param>
        /// <returns>The <see cref="Task{RolTaskDto}"/>.</returns>
        public async Task<RolTaskDto> UpdateAsync(int id, RolTaskDto rolTaskDto)
        {
            await EntityExists(id);
            RolTaskModel rolTask = _mapper.Map<RolTaskModel>(rolTaskDto);

            _dbset.Attach(rolTask);
            _context.Entry(rolTask).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<RolTaskDto>(rolTask);
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            await EntityExists(id);
            var rolTask = await _dbset.SingleOrDefaultAsync(c => c.Id == id);
            _dbset.Remove(rolTask);
            try
            {
                return (await _context.SaveChangesAsync() > 0 ? true : false);

            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The EntityExists.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        public async Task<bool> EntityExists(int id)
        {
            if (await _dbset.AnyAsync(x => x.Id == id))
            {
                return true;
            }
            throw new ArgumentException("Entidad no Encontrado");
        }
    }
}
