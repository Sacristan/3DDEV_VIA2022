using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnimCatcher : MonoBehaviour
{
    Dragon _dragon;

    void Start()
    {
        _dragon = GetComponentInParent<Dragon>();
    }

    void DragonBiteAnim()
    {
        _dragon.Bite();
    }
}
