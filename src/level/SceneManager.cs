using Godot;
using Godot.Collections;
using System;

public class SceneManager : Node
{
    public JsonReader jsonReader = new JsonReader();
    public LinkedLevelList Levels { get; set; } = new LinkedLevelList();
    
    public override void _Ready()
    {
        var data = jsonReader.Read("res://src//level//scene.json");
        var dict = data.Result as Dictionary;
        var sceneDataCollection = dict["scenes"] as Godot.Collections.Array;
        GD.Print(sceneDataCollection);

        foreach (Dictionary sceneData in sceneDataCollection)
        {
            Level level = new Level(
                (string) sceneData["name"],
                (string) sceneData["code"],
                (string) sceneData["scenePath"]
            );
            Levels.Push(level);
        }
        GD.Print(Levels);
    }

    public void RenderScene()
    {
        // render current scene
    }
}
