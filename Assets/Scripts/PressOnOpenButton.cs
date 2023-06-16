using UnityEngine;

public class PressOnOpenButton : MonoBehaviour
{
    [SerializeField] private GameObject _objToDestroy;

    private float _lastEnterTime = -1;
    private float _maaxTimeToSecondEnter = 2;
    private bool _active = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ������ ����� ����� ������ �� ������
        if (!collision.transform.CompareTag("Player"))
            return;

        // �������� �� ������ �������
        if (Time.time - _lastEnterTime <= _maaxTimeToSecondEnter && !_active)
        {
            _active = true;
            Destroy(_objToDestroy);
        }

        // ��������� ����� �������
        _lastEnterTime = Time.time;
    }
}
