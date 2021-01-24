using KuK.Model;
using System.Data.Entity;

namespace KuK.DAL
{
    public class KuKContext : DbContext
    {
        // Your context has been configured to use a 'KuKContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'KuK.DAL.KuKContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'KuKContext' 
        // connection string in the application configuration file.
        public KuKContext()
            : base("name=KuKContext")
        {
        }
        public DbSet<kukUser> Users { get; set; }
        public DbSet<kukNotice> Notices { get; set; }
        public DbSet<kukMessage> Messages { get; set; }
    }
}