using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace QEntangle.Web.Database
{
  public class DatabaseContext : DbContext
  {
    #region Constructors

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    #endregion Constructors

    #region Properties

    public DbSet<UserEntity> QeUser { get; set; }
    public DbSet<ChoiceEntity> Choice { get; set; }

    #endregion Properties

  }
}