using UnityEngine;

public class PressOnOpenButton : MonoBehaviour
{
    [SerializeField] private GameObject _objToDestroy;

    private float _lastEnterTime = -1;
    private float _maaxTimeToSecondEnter = 2;
    private bool _active = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Только игрок может нажать на кнопку
        if (!collision.transform.CompareTag("Player"))
            return;

        // Проверка на второе нажатие
        if (Time.time - _lastEnterTime <= _maaxTimeToSecondEnter && !_active)
        {
            _active = true;
            Destroy(_objToDestroy);
        }

        // Фиксируем время нажатия
        _lastEnterTime = Time.time;
    }
}
