using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    [SerializeField] private int toScene;

    public void RunToScene()
        => SceneManager.LoadScene(toScene);

    private void OnTriggerEnter2D(Collider2D collision)
        => SceneManager.LoadScene(toScene);
}
