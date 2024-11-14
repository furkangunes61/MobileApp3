using System.Collections.ObjectModel;
using System.Formats.Tar;

namespace MobileApp3;

public partial class ToDoPage : ContentPage
{
    public ObservableCollection<TaskItem> Tasks { get; set; }

    public ToDoPage()
    {
        InitializeComponent();
        Tasks = new ObservableCollection<TaskItem>();
        TasksListView.ItemsSource = Tasks;
    }

    // Görev ekleme
    private void OnAddTaskClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(TaskEntry.Text))
        {
            Tasks.Add(new TaskItem { Task = TaskEntry.Text, IsCompleted = false });
            TaskEntry.Text = string.Empty; // Görev eklendikten sonra kutuyu temizle
        }
    }

    // Görev silme
    private void OnDeleteTaskClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button?.BindingContext as TaskItem;
        if (task != null)
        {
            Tasks.Remove(task);
        }
    }

    // Görev düzenleme
    private void OnEditTaskClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button?.BindingContext as TaskItem;
        if (task != null)
        {
            // Düzenleme iþlemi yapýlabilir (örneðin bir pop-up açarak)
            TaskEntry.Text = task.Task;
            Tasks.Remove(task);
        }
    }
}

// Görev item sýnýfý
public class TaskItem
{
    public string Task { get; set; }
    public bool IsCompleted { get; set; }
}

