using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    [SerializeField] private GameObject levelSelectScreen;
    [SerializeField] private GameObject highScoreScreen;
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private AudioSource clickSound;

    public void LoadLevel(int i)
    {

        StartCoroutine(LoadSceneDelayed(i));

    }

    public void QuitGame() 
    {

        StartCoroutine(QuitGameDelayed());

    }

    public void SelectLevel()
    {

        levelSelectScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void ShowHighscoreScreen()
    {

        highScoreScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void BackToMainScreen()
    {

        if (levelSelectScreen.activeSelf)
            levelSelectScreen.SetActive(false);

        if (highScoreScreen.activeSelf)
            highScoreScreen.SetActive(false);

        mainScreen.SetActive(true);

    }

    private IEnumerator LoadSceneDelayed(int i)
    {
        yield return new WaitForSeconds(0.3f);  
        SceneManager.LoadScene(i);            
    }

    public void PlayClickSound()
    {
        clickSound.Play();
    }

    public IEnumerator QuitGameDelayed()
    {
        yield return new WaitForSeconds(0.3f);
        Application.Quit();
    }



}
