using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI
{
    public class AplicationDBcontext : DbContext
    {
        public AplicationDBcontext(DbContextOptions<AplicationDBcontext> options)
            : base(options)
        {
        }

        public DbSet<TodoList> tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoList>()
                .HasKey(t => t.IdTarea);  

        }
    }
}
