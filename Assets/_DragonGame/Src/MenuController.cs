using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Scenes
{
    public const string Menu = "Menu";
    public const string Game = "Game";

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

public class MenuController : MonoBehaviour
{
    private void Start()
    {
        GameCursor.Enable(true);
    }
    
    public void PlayGame()
    {
        Debug.Log("Play Game");
        Scenes.LoadScene(Scenes.Game);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
