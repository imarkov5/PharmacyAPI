
namespace PharmacyAPICardinality.Repository
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
        public DbSet<Pharmacy> Pharmacies { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pharmacy>()
                .Property(p => p.NumberOfFilledPrescriptions)
                .HasComputedColumnSql();
        }*/
        public DbSet<PharmacyAddress> PharmacyAdresses { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Pharmacist> Pharmacists { get; set; }

    }
}
