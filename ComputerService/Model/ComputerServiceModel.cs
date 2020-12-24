namespace ComputerService
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ComputerServiceModel : DbContext
    {
        public ComputerServiceModel()
            : base("name=ComputerServiceModel1")
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<administrator> administrators { get; set; }
        public virtual DbSet<component> components { get; set; }
        public virtual DbSet<person> people { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<service> services { get; set; }
        public virtual DbSet<service_sheet> service_sheet { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.skin)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.administrators)
                .WithRequired(e => e.account)
                .HasForeignKey(e => e.account_idaccount);

            modelBuilder.Entity<account>()
                .HasMany(e => e.users)
                .WithRequired(e => e.account)
                .HasForeignKey(e => e.account_idaccount);

            modelBuilder.Entity<component>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<component>()
                .Property(e => e.manufacturer)
                .IsUnicode(false);

            modelBuilder.Entity<component>()
                .Property(e => e.seria)
                .IsUnicode(false);

            modelBuilder.Entity<component>()
                .HasMany(e => e.service_sheet)
                .WithMany(e => e.components)
                .Map(m => m.ToTable("component_has_service_sheet", "hcibaza"));

            modelBuilder.Entity<person>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .Property(e => e.e_mail)
                .IsUnicode(false);

            modelBuilder.Entity<person>()
                .HasMany(e => e.service_sheet)
                .WithRequired(e => e.person)
                .HasForeignKey(e => e.person_idperson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .Property(e => e.product_number)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.manufacturer)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.seria)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.service_sheet)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.product_idproduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<service>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<service>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<service_sheet>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<service_sheet>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<service_sheet>()
                .HasMany(e => e.services)
                .WithMany(e => e.service_sheet)
                .Map(m => m.ToTable("service_has_service_sheet", "hcibaza"));
        }
    }
}
