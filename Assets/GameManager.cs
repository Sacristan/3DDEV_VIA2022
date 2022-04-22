using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    Hero _hero;

    public Hero Hero
    {
        get
        {
            if (_hero == null) _hero = FindObjectOfType<Hero>();
            return _hero;
        }
    }

    void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);
    }

}
