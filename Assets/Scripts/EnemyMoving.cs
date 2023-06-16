using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private GameObject[] _points;
    [SerializeField] private int _commonDirection = -1; // -1, ���� ���������

    private int _currentIndex;
    private float _speed = 1;
    private bool _reverseMoving = false;
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
            // ������ �������� ��� �������� � ������ �������
            _anim.SetInteger("StayDirection", _commonDirection);
            return;
        }

        var chengeAnim = false;
        
        // ��������� ���������� ����
        if (_currentIndex == -1 || transform.position == _points[_currentIndex].transform.position)
        {
            if (_reverseMoving && --_currentIndex < 0)
            {
                _currentIndex = 0;
                _reverseMoving = false;
            }
            else if (!_reverseMoving && ++_currentIndex >= _points.Length)
            {
                _currentIndex = _points.Length - 1;
                _reverseMoving = true;
            }

            chengeAnim = true;
        }

        // �������� ������� �������� �������
        if (chengeAnim)
            ChengeAnim();

        // ����������� ������ �� ����
        transform.position = Vector2.MoveTowards(
            transform.position, _points[_currentIndex].transform.position, _speed * Time.deltaTime);
    }

    private void ChengeAnim()
    {
        var direction = _points[_currentIndex].transform.position - transform.position;

        if (direction.y < 0)
            _anim.SetInteger("Direction", 0);
        else if (direction.y > 0)
            _anim.SetInteger("Direction", 1);
        else if (direction.x > 0)
            _anim.SetInteger("Direction", 2);
        else if (direction.x < 0)
            _anim.SetInteger("Direction", 3);
    }
}
