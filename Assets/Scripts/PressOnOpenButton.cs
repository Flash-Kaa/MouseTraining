using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressOnOpenButton : MonoBehaviour
{
    [SerializeField] private GameObject _objToDestroy;

    private float _lastEnter = -1;
    private float _timeToSecondEnter = 2;
    private bool _active = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.transform.CompareTag("Player"))
            return;

        var enterTime = Time.time;
        if (enterTime - _lastEnter <= _timeToSecondEnter && !_active)
        {
            _active = true;
            Destroy(_objToDestroy);
        }
        _lastEnter = enterTime;
    }
}
