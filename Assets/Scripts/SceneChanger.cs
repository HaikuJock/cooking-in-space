using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    // buttons
    [SerializeField] Button mainMenuButton, startGameButton, exitGameButton;

    // start function
    public void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenu);
        startGameButton.onClick.AddListener(LevelOne);
        exitGameButton.onClick.AddListener(Quit);
    }


    // other functions
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LevelOne()
    {
        SceneManager.LoadScene(1);

    }
    public void LevelTwo()
    {
        SceneManager.LoadScene(2);

    }
    public void Quit()
    {
        Application.Quit();
    }
}
