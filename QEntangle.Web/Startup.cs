using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QEntangle.Web.Database;
using QEntangle.Web.Database.Identity;
using QEntangle.Web.Interfaces;
using QEntangle.Web.Repositorys;
using System;

namespace QEntangle.Web
{
  public class Startup
  {
    #region Constructors

    public Startup(IConfiguration configuration)
    {
      this.Configuration = configuration;
    }

    #endregion Constructors

    #region Properties

    public IConfiguration Configuration { get; }

    #endregion Properties

    #region Methods

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
        endpoints.MapRazorPages();
      });
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddControllersWithViews();
      services.AddRazorPages();

      services.AddScoped<IChoiceRepository, ChoiceRepository>();

      services.AddIdentity<ApplicationUser, Role>()
        .AddEntityFrameworkStores<DatabaseContext>()
        .AddDefaultTokenProviders()
        .AddDefaultUI();
      //.AddEntityFrameworkStores<DatabaseContext, Guid>()
      //.AddDefaultTokenProviders()
      //.AddUserStore<UserStore<ApplicationUser, Role, ApplicationDbContext, Guid>>()
      //.AddRoleStore<RoleStore<Role, ApplicationDbContext, Guid>>();
    }

    #endregion Methods
  }
}