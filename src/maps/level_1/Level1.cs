using Godot;

public class Level1 : Level
{
    private void OnLevelFinish()
    {
        EmitSignal(nameof(OnLevelFinishSignal), nextLevelScene);
    }
}
