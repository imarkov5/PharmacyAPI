
namespace PharmacyAPICardinality.Database

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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //modelBuilder
        //.Entity<Address>()
        //.HasOne(e => e.Pharmacy)
        //.WithOne(e => e.PharmacyAddress)
        //.OnDelete(DeleteBehavior.ClientCascade);


        /*modelBuilder
            .Entity<Prescription>()
            .HasOne(e => e.Pharmacy)
            .WithMany(e => e.Prescriptions)
            .OnDelete(DeleteBehavior.ClientCascade);
        modelBuilder
            .Entity<Pharmacy>()
            .HasMany(e => e.Prescriptions)
            .WithOne(e => e.Pharmacy)
            .OnDelete(DeleteBehavior.ClientCascade);*/

        //}

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy>()
                .Property(p => p.NumberOfFilledPrescriptions)
                .HasComputedColumnSql();
        }*/

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Pharmacy> Pharmacy { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<Pharmacist> Pharmacist { get; set; }
        //public DbSet<Patient> Patient { get; set; }


    }
}
