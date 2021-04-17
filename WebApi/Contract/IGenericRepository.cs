namespace WebApi.Contract
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="IGenericRepository{T, U}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    /// <typeparam name="U">.</typeparam>
    public interface IGenericRepository<T, U> where T : class where U : class
    {
        /// <summary>
        /// The GetAllAsync.
        /// </summary>
        /// <returns>The <see cref="Task{List{T}}"/>.</returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// The GetAsync.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{T}"/>.</returns>
        Task<T> GetAsync(int id);

        /// <summary>
        /// The InsertAsync.
        /// </summary>
        /// <param name="entity">The entity<see cref="U"/>.</param>
        /// <returns>The <see cref="Task{T}"/>.</returns>
        Task<T> InsertAsync(U entity);

        /// <summary>
        /// The UpdateAsync.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="entity">The entity<see cref="U"/>.</param>
        /// <returns>The <see cref="Task{T}"/>.</returns>
        Task<T> UpdateAsync(int id, U entity);

        /// <summary>
        /// The DeleteAsync.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// The EntityExists.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{bool}"/>.</returns>
        Task<bool> EntityExists(int id);
    }
}
