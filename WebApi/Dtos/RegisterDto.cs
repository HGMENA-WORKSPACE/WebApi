namespace WebApi.Dtos
{
    using System;

    /// <summary>
    /// Defines the <see cref="UserDto" />.
    /// </summary>
    public class RegisterDto : UserDto
    {

        /// <summary>
        /// Gets or sets the UserName.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the PassWord.
        /// </summary>
        public string PassWord { get; set; }
    }
}
