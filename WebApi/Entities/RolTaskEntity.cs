namespace WebApi.Entities
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Defines the <see cref="RolTaskEntity" />.
    /// </summary>
    public class RolTaskEntity : IEntityTypeConfiguration<RolTaskModel>
    {
        /// <summary>
        /// The Configure.
        /// </summary>
        /// <param name="entity">The entity<see cref="EntityTypeBuilder{RolTaskModel}"/>.</param>
        public void Configure(EntityTypeBuilder<RolTaskModel> entity)
        {
            entity.ToTable("RolTask", "test");

            entity.Property(e => e.ChangedBy).HasMaxLength(28);

            entity.Property(e => e.CreatedBy).HasMaxLength(28);

            entity.Property(e => e.DescType)
                .IsRequired()
                .HasMaxLength(7);

            entity.Property(e => e.Guid)
                .IsRequired()
                .HasMaxLength(36);

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(1);
        }
    }
}
