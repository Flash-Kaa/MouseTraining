using UnityEngine;

public class StartAndFinishGame : MonoBehaviour
{
    public void StartGame()
    {
        CommandCenter.StartExecutingCommands = true;
    }

    public void FinishtGame()
    {
        CommandCenter.StartExecutingCommands = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            // Закрыть приложение
            Application.Quit();    
        }
    }
}
