namespace UserQuery.Repositories.Configurations;

internal class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(s => s.Role)
            .HasPrecision(8, 2);

        var users = new List<User>
        {
            new User
            {
                Id = 1,
                UserName = "ADMIN",
                Role = "Admin",
            },
            new User
             {
                Id = 2,
                UserName = "USER",
                Role = "Admin",
            }
        };

        builder.HasData(users);
    }
}
