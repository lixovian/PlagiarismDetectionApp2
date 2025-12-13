using FileAnalysisService.Infrastructure.Data.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FileAnalysisService.Infrastructure.Data;

internal sealed class FileAnalysisDbContext(DbContextOptions<FileAnalysisDbContext> options) : DbContext(options)
{
    public DbSet<ReportDto> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReportDto>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Reports");

            builder.Property(x => x.SubmissionId).IsRequired();

            builder.Property(x => x.IsPlagiarism).IsRequired(false);
            builder.Property(x => x.WordCloudUrl).IsRequired(false);

            builder.HasIndex(x => x.SubmissionId).IsUnique();
        });
    }
}