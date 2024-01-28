using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{


    // Update is called once per frame
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
