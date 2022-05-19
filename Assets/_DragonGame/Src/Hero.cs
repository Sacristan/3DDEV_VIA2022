using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Hero : Character
{
    ThirdPersonController _thirdPersonController;

    private void Start()
    {
        _thirdPersonController = GetComponent<ThirdPersonController>();
    }

    protected override void Die()
    {
        base.Die();
        _thirdPersonController.enabled = false;
    }

}
