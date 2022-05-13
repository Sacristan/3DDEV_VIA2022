using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Character
{
    [SerializeField] float closeEnoughDistance = 3f;
    [SerializeField] float damagePerSecond = 10f;
    Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Vector3 heroPosition = GameManager.instance.Hero.transform.position;
        float distanceToHero = Vector3.Distance(transform.position, heroPosition);
        // Debug.Log("dist to hero: " + distanceToHero);

        if (distanceToHero < closeEnoughDistance)
        {
            GameManager.instance.Hero.AddDamage(Time.deltaTime * damagePerSecond);
            UpdateAttacking(true);
        }
        else
        {
            UpdateAttacking(false);
        }
    }

    void UpdateAttacking(bool flag)
    {
        bool isAttacking = _animator.GetBool("isAttacking");
        if (flag != isAttacking) _animator.SetBool("isAttacking", flag);
    }
}
