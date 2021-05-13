using Microsoft.AspNetCore.Identity;
using System;

namespace QEntangle.Web.Database.Identity
{
  public class ApplicationUser : IdentityUser<Guid> { }

  public class Role : IdentityRole<Guid> { }
}