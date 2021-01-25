using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KnxModels.Model
{
    public partial class KnxDBContext : DbContext
    {
        public KnxDBContext()
        {
        }

        public KnxDBContext(DbContextOptions<KnxDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DecodedTelegram> DecodedTelegrams { get; set; }
        public virtual DbSet<Home> Homes { get; set; }
        public virtual DbSet<KnxProcess> KnxProcesses { get; set; }
        public virtual DbSet<KnxTelegram> KnxTelegrams { get; set; }
        public virtual DbSet<RawLog> RawLogs { get; set; }
        public virtual DbSet<Xmlfile> Xmlfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=192.168.2.1;Initial Catalog=KnxDB;User ID=SA;Password=matikubaK1617!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<DecodedTelegram>(entity =>
            {
                entity.HasKey(e => e.Tid);

                entity.Property(e => e.Tid)
                    .ValueGeneratedNever()
                    .HasColumnName("TID");

                entity.Property(e => e.DestinationAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FrameFormat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Service)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SourceAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).HasColumnType("date");

                entity.Property(e => e.TimestampS)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Home");

                entity.Property(e => e.HomeText)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Time).HasColumnType("datetime");
            });

            modelBuilder.Entity<KnxProcess>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.ProcessIp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ProcessIP");

                entity.Property(e => e.ProcessName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProcessedFile)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<KnxTelegram>(entity =>
            {
                entity.HasKey(e => e.Tid);

                entity.Property(e => e.Tid).HasColumnName("TID");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FrameFormat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RawData)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Service)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp).HasColumnType("date");

                entity.Property(e => e.TimestampS)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RawLog>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PK__RawLogs__5E548648AC392246");

                entity.Property(e => e.FrameFormat)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LogTimestamp).HasColumnType("datetime");

                entity.Property(e => e.RawData)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Service)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Xmlfile>(entity =>
            {
                entity.HasKey(e => e.Fid)
                    .HasName("PK_XMLFiles_1");

                entity.ToTable("XMLFiles");

                entity.Property(e => e.Fid).HasColumnName("FID");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsProcessed).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProcessingPercentage).HasDefaultValueSql("((0))");

                entity.Property(e => e.Xmldata)
                    .IsRequired()
                    .HasColumnType("xml")
                    .HasColumnName("XMLData");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
