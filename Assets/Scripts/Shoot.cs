using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform _shootingPos;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Animator _animator;

    [SerializeField] private bool _shooting;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Instantiate(_bulletPrefab, _shootingPos.position, transform.rotation);

            _animator.Play("Shooting");
        }
    }
}