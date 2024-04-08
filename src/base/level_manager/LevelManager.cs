using Godot;
using System;

public class LevelManager : Node
{
    [Export]
    private NodePath levelContainerPath;
    private Node currentLevel;

    public void Load(PackedScene level)
    {
        if (currentLevel != null)
        {
            currentLevel.QueueFree();
        }

        currentLevel = level.Instance();
        currentLevel.Connect("OnLevelFinishSignal", this, nameof(Load));

        Node levelContainer = GetNode(levelContainerPath);
        if (levelContainer != null)
        {
            levelContainer.AddChild(currentLevel);
        }
    }
}
