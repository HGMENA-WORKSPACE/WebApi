namespace WebApi.Profiles
{
    using AutoMapper;
    using WebApi.Dtos;

    /// <summary>
    /// Defines the <see cref="RolTaskMapper" />.
    /// </summary>
    public class RolTaskMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RolTaskMapper"/> class.
        /// </summary>
        public RolTaskMapper()
        {
            CreateMap<RolTaskModel, RolTaskDto>().ReverseMap();
        }
    }
}
