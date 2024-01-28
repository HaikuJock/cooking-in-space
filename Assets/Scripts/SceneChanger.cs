using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    // buttons
    [SerializeField] Button mainMenuButton, helpButton, creditsButton, playButton, exitButton;

    // start function
    private void Start()
    {
        mainMenuButton.onClick.AddListener(() => MainMenu());
        Debug.Log("Configured main menu button");
        helpButton.onClick.AddListener(() => Help());
        Debug.Log("Configured help button");
        creditsButton.onClick.AddListener(Credits);
        Debug.Log("Configured credits button");
        playButton.onClick.AddListener(Play);
        Debug.Log("Configured play button");
        exitButton.onClick.AddListener(Quit);
        Debug.Log("Configured exit button");

        Debug.Log("End of start function!");
    }

    // other functions
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Help()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        SceneManager.LoadScene(2);
    }

    public void Play()
    {
        SceneManager.LoadScene(5);

    }
    public void Quit()
    {
        Application.Quit();
    }
}
