using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplited : MonoBehaviour
{
    private bool levelCompleted = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !levelCompleted)
        {
            levelCompleted = true;
            CommandCenter.StartExecutingCommands = false;

            // Меняем сцену на следующаю с задержкой
            Invoke("CompleteLevel", 1f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}