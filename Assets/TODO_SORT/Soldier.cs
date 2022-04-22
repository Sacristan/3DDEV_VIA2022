using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Character
{
    void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.materials[1].color = new Color(Random.value, Random.value, Random.value);

        // Debug.Log(gameObject.name);
        // Debug.Log(transform.position);

        // gameObject.AddComponent<Light>();
    }
}
