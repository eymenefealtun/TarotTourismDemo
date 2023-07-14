using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Tourism.Entities.Concrete;
using Tourism.Entities.Models;

namespace Tourism.DataAccess.Concrete.EntityFramework
{
    public class AppDbContext : DbContext
    {

        public DbSet<Operation> Operations { get; set; }
        public DbSet<MainCategory> MainCategory { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<OperationPrice> OperationPrices { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<OperatorUser> OperatorUsers { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<UserLevel> UserLevels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<AgencyUser> AgencyUsers { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<BedType> BedTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<BackgroundTheme> BackgroundThemes { get; set; }


        #region Models

        public DbSet<OperationMain> OperationMain { get; set; }
        public DbSet<DailySale> DailySales { get; set; }
        public DbSet<CustomerOperation> CustomerOperations { get; set; }
        public DbSet<OperationInformation> OperationInformations { get; set; }
        public DbSet<OperatorUserFull> OperatorUserFulls { get; set; }
        public DbSet<IncomeInformation> IncomeInformations { get; set; }

        #endregion

        //public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        //{

        //}
        public AppDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Operation>().HasOne(x => x.OperatorUserCreated).WithMany(x => x.OperatorCreate).HasForeignKey(x => x.CreatedBy);
            modelBuilder.Entity<Operation>().HasOne(x => x.OperatorUserUpdated).WithMany(x => x.OperatorUpdate).HasForeignKey(x => x.LastUpdatedBy);
            //modelBuilder.Entity<OperatorUser>().HasOne(x => x.Id).WithOne(x => x.Preference).HasForeignKey<Preference>(x => x.OperatorUserId);



            // modelBuilder.Entity<OperationInformation>().Property(x => x.RowVersion).IsRowVersion();

            //modelBuilder.Entity<Operation>().Property(x => x.RowVersion).HasColumnType("timestamp").ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            //modelBuilder.Entity<OperationPrice>().Property(x => x.RowVersion).HasColumnType("timestamp").ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Operation>().HasOne(x => x.OperationPrice).WithOne(x => x.Operation).HasForeignKey<OperationPrice>(x=>x.OperationId);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon1"));
        }

        public override int SaveChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(e =>
            {
                if (e.Entity is Operation operation)
                {
                    if (e.State == EntityState.Added)
                    {
                        operation.CreatedDate = DateTime.Now;
                        //operation.CreatedBy = User.currentOperatorUser.
                        operation.LastUpdated = operation.CreatedDate;
                        operation.IsActive = true;
                    }
                    if (e.State == EntityState.Modified)
                    {
                        operation.LastUpdated = DateTime.Now;
                        //operation.LastUpdatedBy =
                    }
                }
            });
            return base.SaveChanges(); //herhangi bir yerde add yaptıktan sonra savechanges'ı çağırdığımda onun öncesinde yukarıdaki kod çalışmış oluyor //bu satır asıl yukarıdaki DbContext'in sace change'si
        }



    }
}
