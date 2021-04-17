namespace WebApi.Entities
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Defines the <see cref="UserEntity" />.
    /// </summary>
    public class UserEntity : IEntityTypeConfiguration<UserModel>
    {
        /// <summary>
        /// The Configure.
        /// </summary>
        /// <param name="entity">The entity<see cref="EntityTypeBuilder{UserModel}"/>.</param>
        public void Configure(EntityTypeBuilder<UserModel> entity)
        {
            entity.ToTable("Users", "test");

            entity.Property(e => e.ChangedBy).HasMaxLength(28);

            entity.Property(e => e.CreatedBy).HasMaxLength(28);

            entity.Property(e => e.Guid)
                        .IsRequired()
                        .HasMaxLength(36);

            entity.Property(e => e.Mail)
                        .IsRequired()
                        .HasMaxLength(28);

            entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(28);

            entity.Property(e => e.PassWord)
                        .IsRequired()
                        .HasMaxLength(512);

            entity.Property(e => e.SureName)
                        .IsRequired()
                        .HasMaxLength(28);

            entity.Property(e => e.TelePhone).HasMaxLength(9);

            entity.Property(e => e.UserName)
                        .IsRequired()
                        .HasMaxLength(28);

            entity.HasOne(d => d.IdRolTaskNavigation)
                        .WithMany(p => p.Users)
                        .HasForeignKey(d => d.IdRolTask)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_RolTask");
        }
    }
}
