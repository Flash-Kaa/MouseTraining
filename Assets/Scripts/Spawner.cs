using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private float _spawnTime;
    private float _timer;
    
    void Start()
    {
        _timer = _spawnTime;
    }

    void Update()
    {
        _timer -= Time.deltaTime;

        // ��� � _timer ������ ������ ����� �������
        if (_timer <= 0)
        {
            Object.Instantiate(_spawnObject, transform.position, transform.rotation);
            _timer = _spawnTime;
        }
    }
}
