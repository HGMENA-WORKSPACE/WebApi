namespace WebApi.Profiles
{
    using AutoMapper;
    using WebApi.Dtos;

    /// <summary>
    /// Defines the <see cref="UserMapper" />.
    /// </summary>
    public class UserMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMapper"/> class.
        /// </summary>
        public UserMapper()
        {
            CreateMap<UserModel, UserDto>().ReverseMap();
        }
    }
}
