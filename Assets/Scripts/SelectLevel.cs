using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] private int toScene;

    // Переключение сцены через кнопку
    public void RunToScene()
        => SceneManager.LoadScene(toScene);

    // Для перехода в меню при достижения последней цели в игре
    private void OnTriggerEnter2D(Collider2D collision)
        => SceneManager.LoadScene(toScene);
}
