using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using orbita_challenge_full_stack_web.Service;

namespace orbita_challenge_full_stack_web
{

   public class BloggingContextFactory : IDesignTimeDbContextFactory<DB_Context>
   {
      public DB_Context CreateDbContext(string[] args)
      {
         // Replace with your server version and type.
         // Use 'MariaDbServerVersion' for MariaDB.
         // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
         var serverVersion = new MariaDbServerVersion(new Version(10, 5, 12));

         var optionsBuilder = new DbContextOptionsBuilder<DB_Context>();
         optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=db_amaisedu", serverVersion);


         return new DB_Context(optionsBuilder.Options);
      }
   }

}