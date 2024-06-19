using UnityEngine;

[RequireComponent(typeof(Transform))]
public class HeartSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private HealthPotion _heartPrefab;

    private void Start()
    {
        _spawnPoint = GetComponent<Transform>();

        HealthPotion healthPotion = Instantiate(_heartPrefab,
            _spawnPoint.position,
            Quaternion.identity);
    }
}