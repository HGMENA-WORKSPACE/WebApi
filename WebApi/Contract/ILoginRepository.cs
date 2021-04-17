namespace WebApi.Contract
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApi.Dtos;

    /// <summary>
    /// Defines the <see cref="ILoginRepository" />.
    /// </summary>
    public interface ILoginRepository <T> where T : class
    {
        /// <summary>
        /// The GetUser.
        /// </summary>
        /// <param name="entity">The entity<see cref="RegisterDto"/>.</param>
        /// <returns>The <see cref="Task{List{UserDto}}"/>.</returns>
        Task<T> GetUser(RegisterDto entity);
        Task<string> GetToken(RegisterDto entity);
    }
}
