using Fiap.Emailify.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Fiap.Emailify.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<UserPreferences> UserPreferences { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<CalendarEvent> CalendarEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPreferences>(entity =>
            {
                entity.ToTable("TBL_USER_PREFERENCES");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("CD_USER");
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("DS_EMAIL");
                entity.Property(e => e.Theme)
                    .HasMaxLength(100)
                    .HasColumnName("DS_THEME");
                entity.Property(e => e.PrimaryColor)
                    .HasMaxLength(50)
                    .HasColumnName("DS_PRIMARY_COLOR");
                entity.Property(e => e.SecondaryColor)
                    .HasMaxLength(50)
                    .HasColumnName("DS_SECONDARY_COLOR");
                entity.Property(e => e.IsDarkTheme)
                    .HasColumnName("FL_DARK_THEME")
                    .IsRequired().HasConversion<int>(); ;
                entity.Property(e => e.IsActive)
                    .HasColumnName("FL_ACTIVE")
                    .IsRequired().HasConversion<int>(); ;
                entity.Property(e => e.LabelsJson).HasColumnName("DS_LABELS_JSON");
                entity.Property(e => e.CategoriesJson).HasColumnName("DS_CATEGORIES_JSON");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.ToTable("TBL_EMAIL");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID_EMAIL");
                entity.Property(e => e.Sender)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("DS_FROM");
                entity.Property(e => e.Recipients)
                    .IsRequired()
                    .HasColumnName("DS_TO")
                    .HasConversion(
                            v => JsonConvert.SerializeObject(v),
                            v => JsonConvert.DeserializeObject<List<string>>(v)
                        ).HasColumnType("CLOB");
                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("DS_SUBJECT");
                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("DS_BODY");
                entity.Property(e => e.SentDate)
                    .IsRequired()
                    .HasColumnName("DT_DATE");
            });

            modelBuilder.Entity<CalendarEvent>(entity =>
            {
                entity.ToTable("TBL_CALENDAR");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("ID_EVENT");
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("DS_TITLE");
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("DS_DESCRIPTION");
                entity.Property(e => e.StartDate)
                    .IsRequired()
                    .HasColumnName("DT_START_DATE");
                entity.Property(e => e.EndDate)
                    .IsRequired()
                    .HasColumnName("DT_END_DATE");
                entity.Property(e => e.Location)
                    .HasMaxLength(200)
                    .HasColumnName("DS_LOCATION");
            });



            base.OnModelCreating(modelBuilder);
        }
    }
}
