using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        Hero.OnDied += OnHeroDied;
    }

    private void OnHeroDied()
    {
        Debug.Log("Hero Died... Restart the game");
        StartCoroutine(RestartSceneRoutine());
    }

    IEnumerator RestartSceneRoutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
