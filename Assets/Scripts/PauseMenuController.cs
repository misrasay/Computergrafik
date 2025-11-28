using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    // Dein PauseMenu Canvas
    public GameObject pauseMenuUI;

    // AudioSource für den Klick-Sound (im Inspector zuweisen!)
    public AudioSource buttonClickAudio;

    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1f; // Spiel normal starten
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false); // Pause-Menü am Anfang ausblenden
        }
    }

    void Update()
    {
        // ESC-Taste: Pause ein/aus
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(true); // Popup zeigen

        Time.timeScale = 0f; // Zeit anhalten
        isPaused = true;
    }

    public void Resume()
    {
        if (buttonClickAudio != null)
            buttonClickAudio.Play(); // Sound abspielen

        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false); // Popup verstecken

        Time.timeScale = 1f; // Zeit weiterlaufen
        isPaused = false;
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartAfterClick());
    }

    private System.Collections.IEnumerator RestartAfterClick()
    {
        if (buttonClickAudio != null)
            buttonClickAudio.Play(); // Sound abspielen

        Time.timeScale = 1f; 
        yield return new WaitForSecondsRealtime(0.2f); // 200 ms warten

        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }

    public void QuitToStartScreen()
    {
        StartCoroutine(QuitAfterClick());
    }

    private System.Collections.IEnumerator QuitAfterClick()
    {
        if (buttonClickAudio != null)
            buttonClickAudio.Play(); // Sound abspielen

        Time.timeScale = 1f;
        yield return new WaitForSecondsRealtime(0.2f); // 200 ms warten

        SceneManager.LoadScene("Start Screen");
    }
}
