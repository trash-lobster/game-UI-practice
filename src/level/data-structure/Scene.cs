using Godot;

public class Scene : Control
{
    public Area2D Exit { get; set; }
    public Area2D Entry { get; set; }

    public override void _Ready()
    {
        Exit = GetNode<Area2D>("NextLevel");
        Entry = GetNode<Area2D>("PreviousLevel");
    }
}