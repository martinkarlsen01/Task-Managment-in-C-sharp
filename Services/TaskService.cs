using Microsoft.EntityFrameworkCore;
using TaskFlow.Models;
using TaskFlow.Data;

namespace TaskFlow.Services;
public class TaskService(AppDBContext db)
{
    public async Task<List<TaskItem>> GetAllTasksAsync() =>
    await db.TaskItems.OrderBy(t => t.DueDate).ToListAsync();

    public async Task AddTaskAsync(TaskItem task)
    {
        db.TaskItems.Add(task);
        await db.SaveChangesAsync();
    }
    
}  

