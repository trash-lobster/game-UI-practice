using Godot;

public class Level : Node2D
{
    [Export]
    protected PackedScene nextLevelScene;
    [Signal]
    protected delegate void OnLevelFinishSignal();
}
