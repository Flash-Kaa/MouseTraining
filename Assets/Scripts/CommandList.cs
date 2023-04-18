using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public static class CommandList
{
    public static List<Vector3> Path = new List<Vector3>();
    public static int Count { get; private set; } = 0;
    public static float BrickSize = 0.6f;

    public static bool GameStart = false;

    public static void Add(string command, int index)
    {
        while (index >= Count)
        {
            Path.Add(new Vector2(0, 0));
            Count++;
        }


        switch (command)
        {
            case "right":
                Path[index] = new Vector3(BrickSize, 0);
                break;

            case "left":
                Path[index] = new Vector3(-BrickSize, 0);
                break;

            case "up":
                Path[index] = new Vector3(0, BrickSize);
                break;

            case "down":
                Path[index] = new Vector3(0, -BrickSize);
                break;
        }
    }

    public static void ReplaceIndex(int lastIndex, int newIndex)
    {
        var temp = Path[lastIndex];
        Path[lastIndex] = new Vector2(0, 0);
    }
}
