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
    public void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenu);
        helpButton.onClick.AddListener(Help);
        creditsButton.onClick.AddListener(Credits);
        playButton.onClick.AddListener(LevelOne);
        exitButton.onClick.AddListener(Quit);
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
    public void Clear()
    {
        SceneManager.LoadScene(3);

    }

    public void Fail()
    {
        SceneManager.LoadScene(4);

    }

    public void LevelOne()
    {
        SceneManager.LoadScene(5);

    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
