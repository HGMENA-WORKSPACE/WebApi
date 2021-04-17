namespace WebApi
{
    using Microsoft.EntityFrameworkCore;
    using WebApi.Entities;

    /// <summary>
    /// Defines the <see cref="ContextDB" />.
    /// </summary>
    public partial class ContextDB : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextDB"/> class.
        /// </summary>
        public ContextDB()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextDB"/> class.
        /// </summary>
        /// <param name="options">The options<see cref="DbContextOptions{ContextDB}"/>.</param>
        public ContextDB(DbContextOptions<ContextDB> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the RolTasks.
        /// </summary>
        public virtual DbSet<RolTaskModel> RolTasks { get; set; }

        /// <summary>
        /// Gets or sets the Users.
        /// </summary>
        public virtual DbSet<UserModel> Users { get; set; }

        /// <summary>
        /// The OnModelCreating.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new RolTaskEntity());
            modelBuilder.ApplyConfiguration(new UserEntity());

            OnModelCreatingPartial(modelBuilder);
        }

        /// <summary>
        /// The OnModelCreatingPartial.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/>.</param>
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
