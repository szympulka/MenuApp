using MenuApp.Core.Entities;
using System.Data.Entity;
using System.Linq;
using MenuWeb.Core.Entities;
using MenuWeb.Core.Entities.BigData;

namespace MenuApp.Core
{
    public class DataContext : DbContext , IDataContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<RecipeLike> RecipeLikes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        //big data
        public DbSet<Logon> Logons { get; set; }

        public DataContext() : base("MenuSite")
        {
          //  Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());
        }


        public T Add<T>(T entry) where T : class
        {
            return Set<T>().Add(entry);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return Set<T>();
        }

        public T Attach<T>(T entry) where T : class
        {
            return Set<T>().Add(entry);
        }

        public T Find<T>(params object[] keys) where T : class
        {
             return Set<T>().Find(keys);
        }

        public T Remove<T>(T entry) where T : class
        {
            return Set<T>().Remove(entry);
        }

        void IDataContext.SaveChanges() 
        {
            base.SaveChanges();
        }
    }
}