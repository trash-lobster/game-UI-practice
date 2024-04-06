using System;
using Godot;

public class MenuButton : MarginContainer
{
    [Export]
    public string InnerString { get; set; } = "Ha ha";
    public Label InnerLabel { get; set; }
    public Button InnerButton { get; set; }
    public Action OnPress { get; set; }
    

    public override void _Ready()
    {
        InnerLabel = (Label) GetNode("Label");
        InnerLabel.Text = InnerString;
        InnerButton = (Button) GetNode("Button");
        InnerButton.Connect("pressed", this, nameof(OnPressHandler));
    }

    private void OnPressHandler()
    {
        OnPress();
    }
}
