using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{


    public static UIController instance;



    private void Awake()
    {
        instance = this;
    }

    public Image[] heartIcons;
    public Sprite heartFull;
    public Sprite heartEmpty;
    public TMP_Text livesText;
    public GameObject gameOverScreen;
    public TMP_Text collectiblesText;
    public GameObject pauseScreen;
    public string mainMenuScene;
    public Image fadeScreen;
    public float fadeSpeed;
    public bool fadingToBlack;
    public bool fadingToWhite;

    // Start is called before the first frame update
    void Start()
    {
        FadeToWhite();
            }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            {
            PauseUnpause();
        }

        if (fadingToWhite)
        {
            fadeScreen.color = new Color(
                fadeScreen.color.r,
                fadeScreen.color.g,
                fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime)
                );
        }

        if (fadingToBlack)
        {
            fadeScreen.color = new Color(
    fadeScreen.color.r,
    fadeScreen.color.g,
    fadeScreen.color.b,
    Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime)
    );
        }
    }

    public void UpdateHealthDisplay(int health, int maxHealth)
    {
        for (int i = 0; i < heartIcons.Length; i++)
        {
            heartIcons[i].enabled = true;


            if (health > i) 
            {
                heartIcons[i].sprite = heartFull;
            }else
            {
                heartIcons[i].sprite = heartEmpty;

                if (maxHealth <= i )
                {
                    heartIcons[i].enabled = false;
                }

            }
        }
    }


    public void UpdateLivesDisplay(int currentLives)
    {
        livesText.text = currentLives.ToString();
    }


    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }


    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;

    }

    public void UpdateCoolectiblesDisplay(int amout)
    {
        collectiblesText.text = amout.ToString();
    }

    public void PauseUnpause()
    {
        if (!pauseScreen.activeSelf)
        { 
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;

        }else
        {
            pauseScreen.SetActive(false);

            Time.timeScale = 1f;
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(mainMenuScene);
        Time.timeScale = 1f;
    }
    public void QuitGameButton()
    {
        Application.Quit();
        Debug.Log("I quit");
    }

    public void FadeToBlack()
    {

        fadingToBlack = true;
        fadingToWhite = false;
    }


    public void FadeToWhite()
    {
        fadingToBlack = false;
        fadingToWhite = true;
    }
}
