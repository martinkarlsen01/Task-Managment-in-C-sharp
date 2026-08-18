namespace TaskFlow.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = ""; // Default to empty string
    public string ?Description { get; set; }
    public DateOnly DueDate { get; set; }
    public Priority Priority { get; set; } = Priority.Medium; // Default priority is Medium
    public bool IsCompleted { get; set; } = false;
    
}


public enum Priority {Low, Medium, High}