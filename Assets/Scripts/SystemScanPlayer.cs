using UnityEngine;
using System;

public class SystemScanPlayer : MonoBehaviour
{
    public event Action<Transform> PlayerDetected;
    public event Action PlayerLost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayerDetected?.Invoke(player.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayerLost?.Invoke();
        }
    }
}