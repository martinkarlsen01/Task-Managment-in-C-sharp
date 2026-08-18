using Microsoft.EntityFrameworkCore;
using TaskFlow.Models;

namespace TaskFlow.Data;

public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
{
    public DbSet<TaskItem> TaskItems => Set<TaskItem>();
}
