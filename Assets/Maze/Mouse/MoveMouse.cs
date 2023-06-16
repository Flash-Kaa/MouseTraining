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

    private int _enterInPortalCount = 0;

    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();

        _startPosition = _target = transform.position;
    }

    void Update()
    {
        // Мышь стоит, если ей не надо выполнять команды
        if (!CommandCenter.StartExecutingCommands)
        {
            _anim.SetInteger("Moving", 0);
            _sprite.flipX = false;
            return;
        }    

        if (_target == transform.position)
        {
            // Изменяем индекс следующей цели
            if(NextIndexOutOfRange())
                return;

            _needNewTarget = true;
        }
            
        if (_needNewTarget)
        {
            Moving move;

            // Нет команды в ячейке
            try
            {
                if (!Enum.TryParse(CultureInfo.CurrentCulture.TextInfo
                        .ToTitleCase(_flowChartContent.transform.GetChild(_pathIndex).GetChild(1).GetChild(0)
                            .GetComponentInChildren<Image>().sprite.name), out move))
                {
                    return;
                }
            }
            catch { return; }

            ChangeTarget(move);

            // Изменяем анимацию
            _anim.SetInteger("Moving", (int)move);
        }

        // Перемещаем объект ближе к текущей цели
        transform.position = Vector2.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("Trap"))
        {
            CommandCenter.HaveCollectableItem = false;
            StartFromBeggining();
        }
        else if (collision.gameObject.CompareTag("SaveProgress"))
        {
            // Сохраняем прогресс
            _startPosition = collision.gameObject.transform.position;

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Portal") && _enterInPortalCount++ % 2 == 0)
        {
            // Телепортируем объект
            transform.position = collision.gameObject.GetComponent<Teleport>().SecondPortal.transform.position;
            _needNewTarget = true;
            NextIndexOutOfRange();
        }
    }

    private void ChangeTarget(Moving move)
    {
        switch (move)
        {
            case Moving.Right:
                _target = transform.position + new Vector3(CommandCenter.BrickSize, 0);
                _sprite.flipX = false;
                break;

            case Moving.Left:
                _target = transform.position + new Vector3(-CommandCenter.BrickSize, 0);
                _sprite.flipX = true;
                break;

            case Moving.Up:
                _target = transform.position + new Vector3(0, CommandCenter.BrickSize);
                break;

            case Moving.Down:
                _target = transform.position + new Vector3(0, -CommandCenter.BrickSize);
                break;
        }

        _needNewTarget = false;
    }

    private bool NextIndexOutOfRange()
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
        // Заканчиваем выполнение комманд и ставим мышь на начальную позицию
        CommandCenter.StartExecutingCommands = false;
        _pathIndex = 0;
        transform.position = _startPosition;
        _target = _startPosition;
    }
}