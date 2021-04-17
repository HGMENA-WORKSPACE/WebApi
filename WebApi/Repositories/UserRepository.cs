namespace WebApi.Repositories
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApi.Contract;
    using WebApi.Dtos;

    /// <summary>
    /// Defines the <see cref="UserRepository" />.
    /// </summary>
    public class UserRepository : IGenericRepository<UserDto, RegisterDto>
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
        private DbSet<UserModel> _dbset;

        /// <summary>
        /// Defines the _passwordHasher.
        /// </summary>
        private readonly IPasswordHasher<UserModel> _passwordHasher;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="ContextDB"/>.</param>
        /// <param name="mapper">The mapper<see cref="IMapper"/>.</param>
        /// <param name="passwordHasher">The passwordHasher<see cref="IPasswordHasher{UserModel}"/>.</param>
        public UserRepository(
            ContextDB context,
            IMapper mapper,
            IPasswordHasher<UserModel> passwordHasher
        )
        {
            _context = context;
            _mapper = mapper;
            _dbset = context.Set<UserModel>();
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// The GetAllAsync.
        /// </summary>
        /// <returns>The <see cref="Task{List{UserDto}}"/>.</returns>
        public async Task<List<UserDto>> GetAllAsync()
        {
            try
            {
                List<UserModel> users = await _dbset.ToListAsync();
                return _mapper.Map<List<UserDto>>(users);
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
        /// <returns>The <see cref="Task{UserDto}"/>.</returns>
        public async Task<UserDto> GetAsync(int id)
        {
            try
            {
                UserModel user = await _dbset.SingleOrDefaultAsync(x => x.Id == id);
                return _mapper.Map<UserDto>(user);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The InsertAsync.
        /// </summary>
        /// <param name="registerDto">The registerDto<see cref="RegisterDto"/>.</param>
        /// <returns>The <see cref="Task{UserDto}"/>.</returns>
        public async Task<UserDto> InsertAsync(RegisterDto registerDto)
        {
            UserModel user = _mapper.Map<UserModel>(registerDto);
            user.Guid = Guid.NewGuid().ToString();
            user.IdRolTask = 1;
            user.CreatedAt = DateTime.Today;
            user.ChangedAt = DateTime.Today;
            user.PassWord = _passwordHasher.HashPassword(user, user.PassWord);

            _dbset.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<UserDto>(user);
        }

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="registerDto">The registerDto<see cref="RegisterDto"/>.</param>
        /// <returns>The <see cref="Task{UserDto}"/>.</returns>
        public async Task<UserDto> UpdateAsync(int id, RegisterDto registerDto)
        {
            await EntityExists(id);
            UserModel user = _mapper.Map<UserModel>(registerDto);
            UserModel userModify = await _dbset.SingleOrDefaultAsync(x => x.Id == id);
            userModify.Name = user.Name;
            userModify.SureName = user.SureName;
            userModify.Mail = user.Mail;
            userModify.BirthDay = user.BirthDay;
            userModify.TelePhone = user.TelePhone;
            userModify.UserName = user.UserName;
            userModify.PassWord = user.PassWord != null ? _passwordHasher.HashPassword(user, user.PassWord) : userModify.PassWord;
            userModify.ChangedAt = DateTime.Today;

            _dbset.Attach(userModify);
            _context.Entry(userModify).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<UserDto>(userModify);
        }

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            await EntityExists(id);
            var user = await _dbset.SingleOrDefaultAsync(x => x.Id == id);
            _dbset.Remove(user);
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
