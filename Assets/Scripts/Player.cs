using UnityEngine;

public class Player : MonoBehaviour, ICollectableVisitor
{
    [SerializeField] private int _money;
    [SerializeField] private int _health;
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out ICollectable collectable))
        {
            Visit((dynamic)collectable);
        }
    }

    public void Visit(Coin coin)
    {
        Destroy(coin.gameObject);

        _money++;
    }

    public void Visit(HealthPotion healthPotion)
    {
        Destroy(healthPotion.gameObject);

        _health++;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}