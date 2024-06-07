using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WinterWhispers.Areas.Identity.Data;
using WinterWhispers.Models;

namespace WinterWhispers.Data;

public class WinterWhispersContext : IdentityDbContext<WinterWhispersUser>
{
    public WinterWhispersContext(DbContextOptions<WinterWhispersContext> options)
        : base(options)
    {
    }

    public DbSet<Models.Forum> Forum { get; set; }
    public DbSet<Models.Topic> Topic { get; set; }

    public DbSet<Models.Comment> Comments { get; set; }


    //public DbSet<Models.Inbox> Inbox { get; set; }



    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);
    //    // Customize the ASP.NET Identity model and override the defaults if needed.
    //    // For example, you can rename the ASP.NET Identity table names and more.
    //    // Add your customizations after calling base.OnModelCreating(builder);
    //}
}
