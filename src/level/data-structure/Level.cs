using Godot;

public class Level : Node2D
{
    [Export]
    public string LevelName { get; set; }
    [Export]
    public string LevelCode { get; set; }
    [Export]
    public string ScenePath { get; set; }
    public Control Scene { get; set; }
    public Level PreviousLevel { get; set; }
    public Level NextLevel { get; set; }

    public Level(string name, string code, string scenePath)
    {
        LevelName = name;
        LevelCode = code;
        ScenePath = scenePath;
        var scene = ResourceLoader.Load<PackedScene>(ScenePath).Instance();
        Scene = (Control) scene;
    }

    public override string ToString()
    {
        return $"{LevelName} - {LevelCode}";
    }
}