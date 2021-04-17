namespace WebApi.Dtos
{
    using System;

    /// <summary>
    /// Defines the <see cref="UserDto" />.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Guid.
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the SureName.
        /// </summary>
        public string SureName { get; set; }

        /// <summary>
        /// Gets or sets the Mail.
        /// </summary>
        public string Mail { get; set; }

        /// <summary>
        /// Gets or sets the BirthDay.
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Gets or sets the TelePhone.
        /// </summary>
        public string TelePhone { get; set; }

        /// <summary>
        /// Gets or sets the UserName.
        /// </summary>
        //public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the PassWord.
        /// </summary>
        //public string PassWord { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreatedAt.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the ChangedBy.
        /// </summary>
        public string ChangedBy { get; set; }

        /// <summary>
        /// Gets or sets the ChangedAt.
        /// </summary>
        public DateTime ChangedAt { get; set; }

        /// <summary>
        /// Gets or sets the IdRolTask.
        /// </summary>
        public int IdRolTask { get; set; }
    }
}
