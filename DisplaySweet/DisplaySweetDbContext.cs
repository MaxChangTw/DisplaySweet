using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DisplaySweet
{
    public class DisplaySweetDbContext : DbContext
    {
        private static readonly string DbConnectionString = $@"Data Source=(LocalDb)\v11.0;AttachDbFilename={AppDomain.CurrentDomain.BaseDirectory}DisplaySweet.mdf;Integrated Security=True;";

        public DisplaySweetDbContext() : base(DbConnectionString)
        {
        }

        public DbSet<Navigation> Navigation { get; set; }

        public DbSet<Child> Child { get; set; }

        public DbSet<Component> Component { get; set; }

        public DbSet<Data> Data { get; set; }

        public DbSet<Caption> Caption { get; set; }

        public DbSet<Style> Style { get; set; }

        public DbSet<Name> Name { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Data>().HasKey(t => new { t.Id, t.ComponentId });

            modelBuilder.Entity<Caption>().HasKey(t => new { t.Id, t.DataId, t.ComponentId });

            modelBuilder.Entity<Style>().HasKey(t => new { t.Id, t.DataId, t.ComponentId });

            modelBuilder.Entity<Name>().HasKey(t => new { t.Id, t.StyleId, t.DataId, t.ComponentId });

            modelBuilder.Entity<Caption>()
                .HasRequired(m => m.Data)
                .WithMany(t => t.Captions)
                .HasForeignKey(m => new { m.DataId, m.ComponentId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Style>()
                .HasRequired(m => m.Data)
                .WithMany(t => t.Styles)
                .HasForeignKey(m => new { m.DataId, m.ComponentId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Name>()
                .HasRequired(m => m.Style)
                .WithMany(t => t.Names)
                .HasForeignKey(m => new { m.DataId, m.ComponentId })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Name>()
                .HasRequired(m => m.Style)
                .WithMany(t => t.Names)
                .HasForeignKey(m => new { m.StyleId, m.DataId, m.ComponentId })
                .WillCascadeOnDelete(false);
        }
    }
}
