namespace P8Maui.Models;

public class Note
{
    public string Id { get; init; } = Guid.NewGuid().ToString("N");
    public string Text { get; set; } = string.Empty;
    public DateTime Date { get; set; } = DateTime.Now;
}
