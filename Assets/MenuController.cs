using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Scenes
{
    public const string Menu = "Menu";
    public const string Game = "Game";
}

public class MenuController : MonoBehaviour
{

    public void PlayGame()
    {
        Debug.Log("Play Game");
        SceneManager.LoadScene(Scenes.Game);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
