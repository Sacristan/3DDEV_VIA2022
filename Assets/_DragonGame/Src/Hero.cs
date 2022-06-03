using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.UI;

public class Hero : Character
{
    ThirdPersonController _thirdPersonController;

    Animator _animator;

    [SerializeField] Slider healthSlider;

    protected override void Start()
    {
        base.Start();
        _thirdPersonController = GetComponent<ThirdPersonController>();
        _animator = GetComponentInChildren<Animator>();
    }

    protected override void Die()
    {
        if (isDead) return;
        _animator.SetTrigger("Die");
        if (_thirdPersonController) _thirdPersonController.enabled = false;
        base.Die();
    }

    public override void AddDamage(float damage)
    {
        base.AddDamage(damage);
        if (!isDead) _animator.SetTrigger("GetHit");
    }

    protected override void UpdateHealth()
    {
        healthSlider.value = HealthPercentage;
    }

}
