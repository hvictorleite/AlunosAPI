using Microsoft.EntityFrameworkCore;

namespace AlunosAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts): base(opts)
        {

        }
    }
}
