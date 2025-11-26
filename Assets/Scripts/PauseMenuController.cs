using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    // Hier trägst du im Inspector dein Canvas "PauseMenu" ein
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1f;          // Spiel normal starten
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);   // Pause-Menü am Anfang ausblenden
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
            pauseMenuUI.SetActive(true);    // Popup zeigen

        Time.timeScale = 0f;                // Zeit anhalten
        isPaused = true;
    }

    public void Resume()
    {
        if (pauseMenuUI != null)
            pauseMenuUI.SetActive(false);   // Popup verstecken

        Time.timeScale = 1f;                // Zeit weiterlaufen
        isPaused = false;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);   // aktuelle Szene neu laden
    }

    public void QuitToStartScreen()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen");       // zurück zur Startseite
    }
}
