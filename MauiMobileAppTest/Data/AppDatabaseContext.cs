using MauiMobileAppTest.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiMobileAppTest.Data
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> dbContextOptions) : base(dbContextOptions) { }

        public virtual DbSet<TodoItem> TodoItems { get; set; }
    }
}
