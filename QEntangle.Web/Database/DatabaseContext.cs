using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QEntangle.Web.Database.Identity;
using System;

namespace QEntangle.Web.Database
{
  public class DatabaseContext : IdentityDbContext<ApplicationUser, Role, Guid>
  {
    #region Constructors

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    #endregion Constructors

    #region Properties

    public DbSet<ChoiceEntity> Choice { get; set; }

    #endregion Properties

    #region Methods

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<ApplicationUser>(b =>
      {
        b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
      });

      builder.Entity<Role>(b =>
      {
        b.Property(u => u.Id).HasDefaultValueSql("newsequentialid()");
      });
    }

    #endregion Methods
  }
}