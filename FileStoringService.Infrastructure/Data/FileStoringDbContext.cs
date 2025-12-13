using FileStoringService.Infrastructure.Data.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FileStoringService.Infrastructure.Data;

internal sealed class FileStoringDbContext(DbContextOptions<FileStoringDbContext> options) : DbContext(options)
{
    public DbSet<StoredFileDto> StoredFiles { get; set; }
    public DbSet<SubmissionDto> Submissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StoredFileDto>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("StoredFiles");

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Size).IsRequired();
            builder.Property(x => x.Sha256).IsRequired();
            builder.Property(x => x.CreatedAt).IsRequired();

            builder.HasIndex(x => x.Sha256);
        });

        modelBuilder.Entity<SubmissionDto>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Submissions");

            builder.Property(x => x.StudentId).IsRequired();
            builder.Property(x => x.AssignmentId).IsRequired();
            builder.Property(x => x.SubmittedAt).IsRequired();
            builder.Property(x => x.StoredFileId).IsRequired();

            builder.HasIndex(x => new { x.AssignmentId, x.StudentId });
            builder.HasOne<StoredFileDto>()
                .WithMany()
                .HasForeignKey(x => x.StoredFileId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}