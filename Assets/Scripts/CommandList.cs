using System.Collections.Generic;
using UnityEngine;

public static class CommandList
{
    public static float BrickSize = 0.6f;

    public static bool GameStart = false;
    public static bool HaveCollectableItem = false;
}

public enum Moving
{
    Stop,
    Right,
    Left,
    Up,
    Down
}