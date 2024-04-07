using Godot;

public class Main : Node2D
{
    public SceneManager SceneManager {get; set; }
    
    public override void _Ready()
    {
        SceneManager = GetNode<SceneManager>("SceneManager");

        var startButton = (MenuButton) GetNode("Start");
        startButton.OnPress = () => { GetTree().ChangeScene(SceneManager.Levels.CurrentLevel.ScenePath); };

        var settingButton = (MenuButton) GetNode("Settings");
        settingButton.OnPress = () => { GD.Print("Hello - settings"); };

        var quitButton = (MenuButton) GetNode("Exit");
        quitButton.OnPress = () => { GetTree().Quit(); };
    }
}