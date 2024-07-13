using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{

    public string mainMenu;

    void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    void Update()
    {
        
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
