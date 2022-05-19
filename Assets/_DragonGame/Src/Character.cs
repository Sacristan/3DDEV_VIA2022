using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public event System.Action OnDied;

    protected float health = 100;
    protected bool isDead = false;

    public void AddDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Die();
    }

    protected virtual void Die()
    {
        if (isDead) return;
        isDead = true;
        OnDied?.Invoke();
    }
}
