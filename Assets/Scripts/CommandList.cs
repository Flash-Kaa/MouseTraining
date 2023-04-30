using System.Collections.Generic;
using UnityEngine;

public static class CommandList
{
    public static List<(Vector3 Vector, Moving Move)> Path = new List<(Vector3, Moving)>();
    public static int Count { get; private set; } = 0;
    public static float BrickSize = 0.6f;

    public static bool GameStart = false;
    public static bool HaveCollectableItem = false;

    public static void Add(string command, int index)
    {
        while (index >= Count)
        {
            Path.Add((new Vector2(0, 0), Moving.Stop));
            Count++;
        }


        switch (command)
        {
            case "right":
                Path[index] = (new Vector3(BrickSize, 0), Moving.Right);
                break;

            case "left":
                Path[index] = (new Vector3(-BrickSize, 0), Moving.Left);
                break;

            case "up":
                Path[index] = (new Vector3(0, BrickSize), Moving.Up);
                break;

            case "down":
                Path[index] = (new Vector3(0, -BrickSize), Moving.Down);
                break;
        }
    }

    public static void Remove(int index)
    {
        Path[index] = (new Vector2(0, 0), Moving.Stop);
    }
}

public enum Moving
{
    Stop,
    Right,
    Left,
    Up,
    Down
}