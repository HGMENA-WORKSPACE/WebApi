namespace WebApi.Repositories
{
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;
    using WebApi.Contract;
    using WebApi.Dtos;
    using WebApi.Services;

    /// <summary>
    /// Defines the <see cref="LoginRepository" />.
    /// </summary>
    public class LoginRepository : ILoginRepository<UserDto>
    {
        /// <summary>
        /// Defines the _dbset.
        /// </summary>
        private DbSet<UserModel> _dbset;

        /// <summary>
        /// Defines the _mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Defines the _passwordHasher.
        /// </summary>
        private readonly IPasswordHasher<UserModel> _passwordHasher;
        private readonly TokenService _tokenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginRepository"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="ContextDB"/>.</param>
        /// <param name="mapper">The mapper<see cref="IMapper"/>.</param>
        /// <param name="passwordHasher">The passwordHasher<see cref="IPasswordHasher{UserModel}"/>.</param>
        public LoginRepository(
            ContextDB context,
            IMapper mapper,
            IPasswordHasher<UserModel> passwordHasher,
            TokenService tokenService
            )
        {
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _dbset = context.Set<UserModel>();
            _tokenService = tokenService;
        }

        /// <summary>
        /// The GetUser.
        /// </summary>
        /// <param name="registerDto">The registerDto<see cref="RegisterDto"/>.</param>
        /// <returns>The <see cref="Task{UserDto}"/>.</returns>
        public async Task<UserDto> GetUser(RegisterDto registerDto)
        {
            UserModel usuario = _mapper.Map<UserModel>(registerDto);

            try
            {
                UserModel user = await _dbset.FirstOrDefaultAsync(x => x.UserName == usuario.UserName);
                PasswordVerificationResult res = _passwordHasher.VerifyHashedPassword(user, user.PassWord, registerDto.PassWord);
                if (user != null && res == PasswordVerificationResult.Success)
                {
                    var token = _tokenService.GenerarToken(user);
                    return _mapper.Map<UserDto>(user);
                }
                return null;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public async Task<string> GetToken(RegisterDto registerDto)
        {
            UserModel usuario = _mapper.Map<UserModel>(registerDto);

            try
            {
                UserModel user = await _dbset.FirstOrDefaultAsync(x => x.UserName == usuario.UserName);
                PasswordVerificationResult res = _passwordHasher.VerifyHashedPassword(user, user.PassWord, registerDto.PassWord);
                if (user != null && res == PasswordVerificationResult.Success)
                {
                    return _tokenService.GenerarToken(user);
                }
                return null;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
