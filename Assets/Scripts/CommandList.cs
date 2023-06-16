public static class CommandCenter
{
    // Три блока Tile'a * размер одного Tile'a
    public static float BrickSize = 0.6f;

    // Надо ли выполнять команды
    public static bool StartExecutingCommands = false;

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