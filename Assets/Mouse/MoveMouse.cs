using UnityEngine;

public class MoveMouse : MonoBehaviour
{
    [SerializeField] private float _speed = 2.5f;

    private Vector2 _startPosition;
    private Vector3 _target;
    private int _pathIndex = -1;

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
            if (_target == transform.position && EndIfUpdIndexOutOfRange())
            {
                return;
            }

            var move = CommandList.Path[_pathIndex].Move;
            if (move == Moving.Right)
            {
                _sprite.flipX = false;
            }
            else if (move == Moving.Left)
            {
                _sprite.flipX = true;
            }
            _anim.SetInteger("Moving", (int)move);

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

            EndIfUpdIndexOutOfRange();

        }
    }

    private bool EndIfUpdIndexOutOfRange()
    {
        _pathIndex++;

        if (CommandList.Count == _pathIndex)
        {
            StartFromBeggining();
            return true;
        }

        _target = transform.position + CommandList.Path[_pathIndex].Vector;
        return false;
    }

    private void StartFromBeggining()
    {
        CommandList.GameStart = false;
        _pathIndex = -1;
        transform.position = _startPosition;
        _target = _startPosition;
    }

    private void SaveProgress(Vector2 newStartPosition)
    {
        _startPosition = newStartPosition;
    }
}