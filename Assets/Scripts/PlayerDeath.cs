using UnityEngine;
using System;

public class PlayerDeath : MonoBehaviour
{
    public static event Action OnPlayerDied;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("bomb"))
        {
            Die();
        }
    }

    void Die()
    {
        OnPlayerDied?.Invoke();
        Destroy(gameObject);
    }
}
