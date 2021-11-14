using Microsoft.EntityFrameworkCore;

namespace orbita_challenge_full_stack_web.Service
{
    public class DB_Context : DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> options) : base(options) {}

        public DbSet<orbita_challenge_full_stack_web.Models.Student> Students {get; set;}

    }

}