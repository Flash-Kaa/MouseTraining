public static class CommandCenter
{
    // ��� ����� Tile'a * ������ ������ Tile'a
    public static float BrickSize = 0.6f;

    // ���� �� ��������� �������
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