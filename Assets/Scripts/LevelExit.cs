using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public Animator anim;

    private bool isEnding;

    public string nextLevel;

    public float waitToEndLevel = 2f;

    public GameObject blocker;
    public float fadeTime = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isEnding)
        {

        if (other.CompareTag("Player"))
        {
            isEnding = true;
            anim.SetTrigger("ended");
                AudioManager.instance.PlaylevelCompleteMusic();
                blocker.SetActive(true);
                StartCoroutine(EndLevelCo());
        }
        }
    }

    IEnumerator EndLevelCo()
    {
        yield return new WaitForSeconds(waitToEndLevel - fadeTime);


        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds(fadeTime);

        InfoTracker.instance.GetInfo();
        InfoTracker.instance.SaveInfo();

        PlayerPrefs.SetString("currentLevel", nextLevel);

        SceneManager.LoadScene(nextLevel);
    }

}
