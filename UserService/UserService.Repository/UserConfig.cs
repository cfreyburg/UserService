using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.Domain.Entities;

namespace UserService.Repository
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(q => q.Email)
                .HasMaxLength(25);
            builder.Property(q => q.Name)
                .HasMaxLength(25);
            builder.Ignore(q => q.Password);
        }
    }
}
