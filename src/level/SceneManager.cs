using Godot;
using Godot.Collections;
using System;

public class SceneManager : Node
{
    public JsonReader jsonReader = new JsonReader();
    public LinkedLevelList Levels { get; set; } = new LinkedLevelList();
    public MenuButton NextLevelButton { get; set; }
    public MenuButton PreviousLevelButton { get; set; }
    
    public override void _Ready()
    {
        var data = jsonReader.Read("res://src//level//scene.json");
        var dict = data.Result as Dictionary;
        var sceneDataCollection = dict["scenes"] as Godot.Collections.Array;

        foreach (Dictionary sceneData in sceneDataCollection)
        {
            Level level = new Level(
                (string) sceneData["name"],
                (string) sceneData["code"],
                (string) sceneData["scenePath"]
            );
            Levels.Push(level);
        }

        SetUpInteraction();
    }

    public void SetUpInteraction()
    {
        NextLevelButton = (MenuButton) Levels.CurrentLevel.Scene.GetNode("NextLevel");
        NextLevelButton.OnPress = () => { this.GoToNextScene(); };
        PreviousLevelButton = (MenuButton) Levels.CurrentLevel.Scene.GetNode("PreviousLevel");
        PreviousLevelButton.OnPress = () => { this.GoToPreviousScene(); };
    }

    public void GoToNextScene()
    {
        Levels.MoveToNextLevel();
        RenderScene();
    }

    public void GoToPreviousScene()
    {
        Levels.MoveToPreviousLevel();
        RenderScene();
    }

    private void RenderScene()
    {
        GetTree().ChangeScene(Levels.CurrentLevel.ScenePath);
    }
}
