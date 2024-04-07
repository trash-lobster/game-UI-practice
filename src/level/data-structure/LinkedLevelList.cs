using System;
using System.Text;
using Godot;

public class LinkedLevelList : Node2D
{
    public Level CurrentLevel { get; set; }
    public Level Head { get; set; }
    public Level Last { get; set; }

    public override void _Ready()
    {
        RestoreState();
    }

    private void SetHead(Level head)
    {
        Head = head;
        Last = head;
        CurrentLevel = head;
    }

    public void Push(Level newLevel)
    {
        if (CurrentLevel == null)
        {
            SetHead(newLevel);
        }
        else
        {
            Last.NextLevel = newLevel;
            Last = Last.NextLevel;
        }
    }

    public Level Pop()
    {
        if (CurrentLevel == null)
        {
            return null;
        }
        var last = Last;
        Last = Last.PreviousLevel;
        Last.NextLevel = null;
        return last;
    }

    public void MoveToNextLevel()
    {
        if (CurrentLevel.NextLevel != null)
        {
            CurrentLevel = CurrentLevel.NextLevel;
            UpdateState(CurrentLevel.LevelCode);
        }
        else 
        {
            // nothing happens for now, or we finish the game
        }
    }

    public void MoveToPreviousLevel()
    {
        if (CurrentLevel.PreviousLevel != null)
        {
            CurrentLevel = CurrentLevel.PreviousLevel;
            UpdateState(CurrentLevel.LevelCode);
        }
    }

    private void UpdateConnect()
    {
        // disconnect previous signals and reconnect signals
    }

    private static void UpdateState(string levelCode)
    {
        var config = new ConfigFile();

        // Load data from a file.
        Error err = config.Load("user://level.cfg");

        // If the file didn't load, ignore it.
        if (err != Error.Ok)
        {
            return;
        }

        config.SetValue("state", "currentLevel", levelCode);
        // render scene
    }

    public void RestoreState()
    {
        var config = new ConfigFile();

        // Load data from a file.
        Error err = config.Load("user://level.cfg");

        // If the file does not exist, create a storage file
        if (err != Error.Ok)
        {
            config.Save("user://level.cfg");
            return;
        }

        // Iterate over all sections.
        foreach (string section in config.GetSections())
        {
            if (section == "state")
            {
                var levelCode = (string) config.GetValue(section, "currentLevel");
                var currentLevel = SearchLevel(levelCode);
                CurrentLevel = currentLevel;
            }
        }
    }

    private Level SearchLevel(string levelCode)
    {
        Level traverse = Head;
        try 
        {
            while (traverse.LevelCode != levelCode)
            {
                traverse = traverse.NextLevel;
            }
        }
        catch (NullReferenceException ex)
        {
            GD.Print(ex);
            GetTree().Quit();
        }
        return traverse;
    }

    public override string ToString()
    {
        Level traverse = Head;
        StringBuilder sb = new StringBuilder();
        while (traverse != null)
        {
            sb.AppendLine(traverse.ToString());
            traverse = traverse.NextLevel;
        }
        return sb.ToString();
    }
}