
namespace PharmacyAPICardinality.Context

{
    public class DataContext : DbContext
    {
        public IConfiguration _config { get; set; }
        public DataContext(IConfiguration config)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DatabaseConnection"));
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Username)
            .IsUnique();

            builder.Entity<Pharmacy>(entity =>
            {
                entity.Property(e => e.NumOfFilledRXCurrentMonth)
                .HasComputedColumnSql("([dbo].[countFilledRxCurrentMonth]([Id]))", false)
                .HasColumnName("NumOfFilledRxCurrentMonth");
            });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pharmacy> Pharmacy { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Pharmacist> Pharmacist { get; set; }


    }
}
