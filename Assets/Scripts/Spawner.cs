using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private float _spawnTime;
    private float _timer;
    
    // Start is called before the first frame update
    void Start()
    {
        _timer = _spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            Object.Instantiate(_spawnObject, transform.position, transform.rotation);
            _timer = _spawnTime;
        }
    }
}
