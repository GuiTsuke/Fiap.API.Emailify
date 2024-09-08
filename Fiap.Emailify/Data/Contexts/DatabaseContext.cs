using Fiap.Emailify.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Fiap.Emailify.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<UserPreferences> UserPreferences { get; set; }
        public virtual DbSet<Email> Email { get; set; }
        public virtual DbSet<CalendarEvent> Calendar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPreferences>(entity =>
            {
                entity.ToTable("TBL_USER_PREFERENCES");
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).ValueGeneratedOnAdd().HasColumnName("ID_USER");
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Email).HasColumnName("DS_EMAIL");
                entity.Property(e => e.Theme).HasMaxLength(100).HasColumnName("DS_THEME").IsRequired();
                entity.Property(e => e.PrimaryColor).HasColumnName("DS_PRIMARY_COLOR").IsRequired();
                entity.Property(e => e.SecondaryColor).HasColumnName("DS_SECONDARY_COLOR").IsRequired();
                entity.Property(e => e.Labels).HasColumnName("DS_LABELS");
                entity.Property(e => e.Categories).HasColumnName("DS_CATEGORIES");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.ToTable("TBL_EMAIL");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID_EMAIL");
                entity.Property(e => e.EmailId).HasColumnName("GUID_EMAIL");
                entity.Property(e => e.From).HasColumnName("DS_FROM").IsRequired();
                entity.Property(e => e.To).HasMaxLength(100).HasColumnName("DS_TO").IsRequired();
                entity.Property(e => e.Subject).HasColumnName("DS_SUBJECT");
                entity.Property(e => e.Body).HasColumnName("DS_BODY").IsRequired();
                entity.Property(e => e.Timestamp).HasColumnName("DT_DATE").IsRequired();
            });

            modelBuilder.Entity<CalendarEvent>(entity =>
            {
                entity.ToTable("TBL_CALENDAR");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd().HasColumnName("ID_EVENT");
                entity.Property(e => e.EventId).HasColumnName("GUID_EVENT");
                entity.Property(e => e.Title).HasColumnName("DS_TITLE").IsRequired();
                entity.Property(e => e.Description).HasMaxLength(100).HasColumnName("DS_DESCRIPTION").IsRequired();
                entity.Property(e => e.Date).HasColumnName("DS_DATE").IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
