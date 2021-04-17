namespace WebApi.Profiles
{
    using AutoMapper;
    using WebApi.Dtos;

    /// <summary>
    /// Defines the <see cref="RegisterMapper" />.
    /// </summary>
    public class RegisterMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterMapper"/> class.
        /// </summary>
        public RegisterMapper()
        {
            CreateMap<UserModel, RegisterDto>().ReverseMap();
        }
    }
}
