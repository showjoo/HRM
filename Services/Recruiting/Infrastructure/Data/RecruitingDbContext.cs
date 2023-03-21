using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data;

public class RecruitingDbContext : DbContext // database
{
    public RecruitingDbContext(DbContextOptions<RecruitingDbContext> options) : base(options)
    {
        
    }

    public DbSet<Job> Jobs {get; set; } // table 
    public DbSet<Submission> Submissions { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<JobStatusLookUp> JobStatusLookUps { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // I can use this method to do Fluent API way to do any schema changes just like Data Annotations
        modelBuilder.Entity<Candidate>(ConfigureCandidate);
        // Action<EntityTypeBuilder<TEntity>> buildAction
        // Action<int> buildAction
    }

    private void ConfigureCandidate(EntityTypeBuilder<Candidate> builder)
    {
        // we can establish the rules for candidate table
        builder.HasKey(c => c.Id);
        builder.Property(c => c.FirstName).HasMaxLength(100);
        builder.HasIndex(c => c.Email).IsUnique();
        builder.Property(c => c.CreatedOn).HasDefaultValueSql("getdate()");
    }
}