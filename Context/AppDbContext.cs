using AlunosAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AlunosAPI.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts): base(opts)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno
                {
                    Id = 1,
                    Nome = "Maria da Pena",
                    Email = "mariapena@yahoo.com",
                    Idade = 23
                },
                new Aluno
                {
                    Id = 2,
                    Nome = "Manuel Bueno",
                    Email = "manuelbueno@yahoo.com",
                    Idade = 22
                }
            );
        }*/
    }
}
