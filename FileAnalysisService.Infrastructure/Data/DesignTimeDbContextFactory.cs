using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FileAnalysisService.Infrastructure.Data;

internal sealed class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FileAnalysisDbContext>
{
    public FileAnalysisDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<FileAnalysisDbContext>()
            .UseNpgsql("Host=127.0.0.1;Port=6432;Database=fileanalysis;Username=postgres;Password=postgres;")
            .Options;

        return new FileAnalysisDbContext(options);
    }
}