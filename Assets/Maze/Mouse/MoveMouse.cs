using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class MoveMouse : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;
    [SerializeField] private GameObject _flowChartContent;

    private Vector2 _startPosition;
    private Vector3 _target;
    private int _pathIndex = 0;
    private bool _needNewTarget = false;

    private SpriteRenderer _sprite;
    private Animator _anim;

    private byte _enterInPortalCount = 0;

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();

        _startPosition = _target = transform.position;
    }

    void Update()
    {
        if (CommandList.GameStart)
        {
            if (_target == transform.position)
            {
                if(EndIfUpdIndexOutOfRange())
                    return;

                _needNewTarget = true;
            }
            
            if (_needNewTarget)
            {
                Moving move;

                try
                {
                    if (!Enum.TryParse(CultureInfo.CurrentCulture.TextInfo
                            .ToTitleCase(_flowChartContent.transform.GetChild(_pathIndex).GetChild(1).GetChild(0)
                                .GetComponentInChildren<Image>().sprite.name), out move))
                    {
                        return;
                    }
                }
                catch
                {
                    return;
                }

                switch (move)
                {
                    case Moving.Right:
                        _target = transform.position + new Vector3(CommandList.BrickSize, 0);
                        break;

                    case Moving.Left:
                        _target = transform.position + new Vector3(-CommandList.BrickSize, 0);
                        break;

                    case Moving.Up:
                        _target = transform.position + new Vector3(0, CommandList.BrickSize);
                        break;

                    case Moving.Down:
                        _target = transform.position + new Vector3(0, -CommandList.BrickSize);
                        break;
                }

                if (move == Moving.Right)
                {
                    _sprite.flipX = false;
                }
                else if (move == Moving.Left)
                {
                    _sprite.flipX = true;
                }
                _anim.SetInteger("Moving", (int)move);

                _needNewTarget = false;
            }

            transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
        }
        else
        {
            _anim.SetInteger("Moving", 0);
            _sprite.flipX = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Walls") 
            || collision.gameObject.CompareTag("Trap"))
        {
            CommandList.HaveCollectableItem = false;
            StartFromBeggining();
        }

        else if (collision.gameObject.CompareTag("SaveProgress"))
        {
            Destroy(collision.gameObject);
            SaveProgress(collision.gameObject.transform.position);
        }

        else if (collision.gameObject.CompareTag("Portal") && _enterInPortalCount++ % 2 == 0)
        {
            transform.position = 
                collision.gameObject.GetComponent<Teleport>().SecondPortal.transform.position;
            _needNewTarget = true;
            EndIfUpdIndexOutOfRange();

        }
    }

    private bool EndIfUpdIndexOutOfRange()
    {
        _pathIndex++;

        if (_flowChartContent.transform.childCount == _pathIndex)
        {
            StartFromBeggining();
            return true;
        }

        return false;
    }

    private void StartFromBeggining()
    {
        CommandList.GameStart = false;
        _pathIndex = 0;
        transform.position = _startPosition;
        _target = _startPosition;
    }

    private void SaveProgress(Vector2 newStartPosition)
    {
        _startPosition = newStartPosition;
    }
}