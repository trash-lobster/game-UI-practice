using Godot;

public class Main : Node2D
{
    public override void _Ready()
    {
        var startButton = (MenuButton) GetNode("Start");
        startButton.OnPress = () => { GD.Print("Hello - start"); };

        var settingButton = (MenuButton) GetNode("Settings");
        settingButton.OnPress = () => { GD.Print("Hello - settings"); };

        var quitButton = (MenuButton) GetNode("Exit");
        quitButton.OnPress = () => { GetTree().Quit(); };
    }
}