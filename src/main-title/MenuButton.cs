using System;
using Godot;

public class MenuButton : MarginContainer
{
    [Export]
    public string InnerString { get; set; } = "Ha ha";
    public Label InnerLabel { get; set; }
    public Action OnPress { get; set; }

    // public MenuButton(string innerText, Action onPress)
    // {
    //     InnerString = innerText;
    //     OnPress = onPress;
    // }

    public override void _Ready()
    {
        InnerLabel = (Label) GetNode("Label");
        InnerLabel.Text = InnerString;
        var button = (Button)GetNode("Button");
        button.Connect("pressed", this, nameof(OnPressHandler));
    }

    public void OnPressHandler()
    {
        //OnPress();
        GD.Print("Hello!");
    }
}
