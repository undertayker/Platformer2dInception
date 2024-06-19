using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    
    private SystemScanPlayer _scanPlayer;
    private Rigidbody2D _rigRigidbody;
    private Transform _target;
    private Transform _currentTarget;

    private int _directionMove;

    public void Awake()
    {
        _scanPlayer = GetComponentInChildren<SystemScanPlayer>();
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Flip();
    }

    public void OnEnable()
    {
        _scanPlayer.PlayerDetected += SetTarget;
        _scanPlayer.PlayerLost += ()=> SetTarget(_target);
    }

    public void OnDisable()
    {
        _scanPlayer.PlayerDetected -= SetTarget;
        _scanPlayer.PlayerLost -= () => SetTarget(_target);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            player.TakeDamage(_damage);
        }
    }

    public void Init(Transform target)
    {       
        _currentTarget = target;
        _target = target;
    }

    public void SetTarget(Transform target)
    {
        _currentTarget = target;
    }
    
    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Flip()
    {
        if (transform.position.x > _currentTarget.position.x)
        {
            _spriteRenderer.flipX = false;
            _directionMove = -1;
        }
        else
        {
            _spriteRenderer.flipX = true;
            _directionMove = 1;
        }

        _rigRigidbody.velocity = new Vector2(_speed * _directionMove, _rigRigidbody.velocity.y);
    }
}