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

    // G�rev ekleme
    private void OnAddTaskClicked(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(TaskEntry.Text))
        {
            Tasks.Add(new TaskItem { Task = TaskEntry.Text, IsCompleted = false });
            TaskEntry.Text = string.Empty; // G�rev eklendikten sonra kutuyu temizle
        }
    }

    // G�rev silme
    private void OnDeleteTaskClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button?.BindingContext as TaskItem;
        if (task != null)
        {
            Tasks.Remove(task);
        }
    }

    // G�rev d�zenleme
    private void OnEditTaskClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var task = button?.BindingContext as TaskItem;
        if (task != null)
        {
            // D�zenleme i�lemi yap�labilir (�rne�in bir pop-up a�arak)
            TaskEntry.Text = task.Task;
            Tasks.Remove(task);
        }
    }
}

// G�rev item s�n�f�
public class TaskItem
{
    public string Task { get; set; }
    public bool IsCompleted { get; set; }
}

