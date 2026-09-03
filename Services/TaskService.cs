using Microsoft.EntityFrameworkCore;
using TaskFlow.Models;
using TaskFlow.Data;

namespace TaskFlow.Services;
public class TaskService(AppDBContext db)
{
    public async Task<List<TaskItem>> GetAllTasksAsync() =>
    await db.TaskItems.OrderBy(t => t.DueDate).ToListAsync();

    public async Task AddTaskAsync(TaskItem task) //method for adding a new task to the database
    {
        db.TaskItems.Add(task);
        await db.SaveChangesAsync();
    }

    public async Task ToggleTaskCompletionAsync(int taskId) //method for toggling the completion status of a task by its ID
    {
        var task = await db.TaskItems.FindAsync(taskId);
        if (task != null)
        {
            task.IsCompleted = !task.IsCompleted;
            await db.SaveChangesAsync();
        }
    }

    public async Task DeleteTaskAsync(int taskId) //method for deleting a task by its ID
    {
        var task = await db.TaskItems.FindAsync(taskId);
        if (task != null)
        {
            db.TaskItems.Remove(task);
            await db.SaveChangesAsync();
        }
    }

    public async Task<Dictionary<DateOnly, List<TaskItem>>> GetTasksForMonthAsync(int year, int month) //method for grouping tasks by their due date
    {
        var tasks = await db.TaskItems
            .Where(t => t.DueDate.Year == year && t.DueDate.Month == month)
            .ToListAsync();
            
        return tasks
            .GroupBy(t => t.DueDate)
            .ToDictionary(g => g.Key, g => g.ToList());
    }
    
}  

