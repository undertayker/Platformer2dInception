using UnityEngine;

[RequireComponent(typeof(Transform))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _player;

    private void Start()
    {
        _spawnPoint = GetComponent<Transform>();

        Enemy enemy = Instantiate(_enemyPrefab,
            _spawnPoint.position,
            transform.rotation);

        enemy.Init(_target);
    }
}