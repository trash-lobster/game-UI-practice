using Godot;
using System;

public class MainMenu : Control
{
    [Export]
    private NodePath levelManagerPath;
    [Export]
    private PackedScene firstLevelScene;

    private void OnStartButtonClick()
    {
        LevelManager levelManager = (LevelManager) GetNode(levelManagerPath);
        if (levelManager != null && firstLevelScene != null)
        {
            levelManager.Load(firstLevelScene);
            QueueFree();
        }
    }
}
