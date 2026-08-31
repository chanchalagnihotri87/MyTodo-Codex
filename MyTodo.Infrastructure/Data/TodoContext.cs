using Microsoft.EntityFrameworkCore;
using MyTodo.Domain.Entities;

namespace MyTodo.Data;

public class TodoContext(DbContextOptions<TodoContext> options) : DbContext(options)
{
    public DbSet<LifeArea> LifeAreas => Set<LifeArea>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
