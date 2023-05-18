using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private GameObject[] _points;
    [SerializeField] private int _commonDirection = -1;

    private int _currentIndex;
    private float _speed = 1;
    private bool _reverse = false;
    private Animator _anim;


    void Start()
    {
        _anim = GetComponent<Animator>();
        _currentIndex = -1;
    }

    void Update()
    {
        if (_commonDirection != -1)
        {
            _anim.SetInteger("StayDirection", _commonDirection);
            return;
        }

        var chengeAnim = false;

        if (_currentIndex == -1 || transform.position == _points[_currentIndex].transform.position)
        {
            if (_reverse && --_currentIndex < 0)
            {
                _currentIndex = 0;
                _reverse = false;
            }
            else if (!_reverse && ++_currentIndex >= _points.Length)
            {
                _currentIndex = _points.Length - 1;
                _reverse = true;
            }

            chengeAnim = true;
        }

        if (chengeAnim)
        {
            var dir = _points[_currentIndex].transform.position - transform.position;

            if (dir.y < 0)
                _anim.SetInteger("Direction", 0);
            else if (dir.y > 0)
                _anim.SetInteger("Direction", 1);
            else if (dir.x > 0)
                _anim.SetInteger("Direction", 2);
            else if (dir.x < 0)
                _anim.SetInteger("Direction", 3);                
        }

        transform.position = Vector2.MoveTowards(
            transform.position, _points[_currentIndex].transform.position, _speed * Time.deltaTime);
    }
}
