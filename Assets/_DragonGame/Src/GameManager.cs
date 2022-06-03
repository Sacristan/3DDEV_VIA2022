using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public static class GameCursor
{
    public static void Enable(bool flag)
    {
        Cursor.visible = flag;
        Cursor.lockState = flag ? CursorLockMode.None : CursorLockMode.Locked;
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    Hero _hero;
    bool isChangingScene = false;
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
        GameCursor.Enable(false);
    }

    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame) LoadMainMenu();
    }

    void LoadMainMenu()
    {
        if (isChangingScene) return;
        isChangingScene = true;
        Scenes.LoadScene(Scenes.Menu);
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
