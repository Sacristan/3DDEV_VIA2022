using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Hero : MonoBehaviour
{
    float health = 100;
    bool isDead = false;

    ThirdPersonController _thirdPersonController;

    private void Start()
    {
        _thirdPersonController = GetComponent<ThirdPersonController>();
    }

    void AddDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Die();
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        _thirdPersonController.enabled = false;
    }

}
