using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public event System.Action OnDied;

    [SerializeField] protected float maxHealth = 100;
    protected float health = 0;
    protected bool isDead = false;

    protected virtual void Start()
    {
        health = maxHealth;
    }

    public virtual void AddDamage(float damage)
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
