using Godot;

public class TitleScreen : Node2D
{
    public override void _Ready()
    {
        var startButton = (MenuButton)GetNode("Start");
        startButton.OnPress = () => GD.Print("Hello - start");

        var settingButton = (MenuButton)GetNode("Settings");
        startButton.OnPress = () => GD.Print("Hello - settings");

        var quitButton = (MenuButton)GetNode("Exit");
        startButton.OnPress = () => GetTree().Quit();
    }
}