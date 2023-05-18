using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverCurrentAnim : MonoBehaviour
{
    [SerializeField] private float _timeToBegginAnimInSeconds = 0;

    private Animator _anim;
    private bool _isBeggin = false;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isBeggin)
        {
            _timeToBegginAnimInSeconds -= Time.deltaTime;

            if (_timeToBegginAnimInSeconds <= 0)
            {
                _anim.SetTrigger("beggin");
                _isBeggin = true;
            }
        }
    }
}
