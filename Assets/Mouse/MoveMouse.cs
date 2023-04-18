using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MoveMouse : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;

    Vector2 _startPosition;
    int _pathIndex = -1;
    Vector3 _target;

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = _target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (CommandList.GameStart)
        {
            if (_target == transform.position)
            {
                _pathIndex++;

                if (CommandList.Count == _pathIndex)
                {
                    CommandList.GameStart = false;
                    _pathIndex = -1;
                    transform.position = _startPosition;
                }

                _target = transform.position + CommandList.Path[_pathIndex];
            }

            var target = transform.position + CommandList.Path[_pathIndex];
            transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        }
    }
}
