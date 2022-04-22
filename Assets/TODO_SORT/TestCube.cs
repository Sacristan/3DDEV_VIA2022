using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCube : MonoBehaviour
{
    void Start()
    {
        GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;

        Debug.Log("Found character: " + FindObjectOfType<Character>().gameObject.name);
    }

}
