using System.IO;
using Godot;

public class JsonReader : Control
{
    public JSONParseResult Read(string path)
    {
        var file = new Godot.File();

        if (!file.FileExists(path))
        {
            throw new IOException();
        }

        file.Open(path, Godot.File.ModeFlags.Read);
        return JSON.Parse(file.GetAsText());
    }
}