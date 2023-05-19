using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ToUpAnim : MonoBehaviour
{
    [SerializeField] private float _moveOn = 0;
    [SerializeField] private float _speed = 0.15f;

    private Vector3 _target;

    private void Start()
    {
        _target = transform.position + new Vector3(0, _moveOn);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (transform.position == _target)
        {
            Destroy(gameObject);
        }
    }
}
