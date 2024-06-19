using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Transform))]
public class PlayerMovement : MonoBehaviour
{
    private const string Walk = nameof(Walk);
    private const string Horizontal = nameof(Horizontal);
    private const string IsGround = nameof(IsGround);

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private float _radiusGroundCheck;

    private Quaternion _rotationRight = Quaternion.identity;
    private Quaternion _rotationLeft = Quaternion.Euler(0, 180, 0);

    private bool _isGround;
    private Vector2 _moveVector;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _groundCheck = GetComponent<Transform>();
    }

    private void Update()
    {
        Move();
        Jump();
        Flip();
    }

    private void Move()
    {
        _moveVector.x = Input.GetAxis(Horizontal);
        _animator.SetFloat(Walk, Mathf.Abs(_moveVector.x));

        _rigidbody.velocity = new Vector2(_moveVector.x * _speed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        _isGround = Physics2D.OverlapCircle(_groundCheck.position, _radiusGroundCheck, _ground);
        _animator.SetBool(IsGround, _isGround);

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }

    private void Flip()
    {
        if (_moveVector.x > 0.01)
        {
            transform.rotation = _rotationRight;        
        }
        else if (_moveVector.x < 0)
        {
            transform.rotation = _rotationLeft;

        }
    }
}