namespace WebApi
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="RolTaskModel" />.
    /// </summary>
    public partial class RolTaskModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RolTaskModel"/> class.
        /// </summary>
        public RolTaskModel()
        {
            Users = new HashSet<UserModel>();
        }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Guid.
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// Gets or sets the Type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the DescType.
        /// </summary>
        public string DescType { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreatedAt.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the ChangedBy.
        /// </summary>
        public string ChangedBy { get; set; }

        /// <summary>
        /// Gets or sets the ChangedAt.
        /// </summary>
        public DateTime? ChangedAt { get; set; }

        /// <summary>
        /// Gets or sets the Users.
        /// </summary>
        public virtual ICollection<UserModel> Users { get; set; }
    }
}
