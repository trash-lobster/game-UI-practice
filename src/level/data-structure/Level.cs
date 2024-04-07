using Godot;

public class Level : Node2D
{
    [Export]
    public string LevelName { get; set; }
    [Export]
    public string LevelCode { get; set; }
    [Export]
    public string Scene { get; set; }
    public Level PreviousLevel { get; set; }
    public Level NextLevel { get; set; }

    public Level(string name, string code, string scenePath)
    {
        LevelName = name;
        LevelCode = code;
        Scene = scenePath;
    }

    public void GoToNextLevel()
    {
        // emit signal to change scene to next level
    }

    public void GoToLastLevel()
    {

    }

    public override string ToString()
    {
        return $"{LevelName} - {LevelCode}";
    }
}