using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplited : MonoBehaviour
{
    private AudioSource _finishSound;
    private bool levelCompleted = false;

    void Start()
    {
        //_finishSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !levelCompleted)
        {
            //_finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 1f);
            CommandList.GameStart = false;
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}