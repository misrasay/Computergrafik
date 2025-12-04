using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUnlocker : MonoBehaviour
{
    [Header("UI")]
    // Hier tragen wir später dein EndPanel ein
    public GameObject endPanel;

    private int totalMathBricks;
    private int destroyedMathBricks;

    private void Start()
    {
        // Endscreen am Anfang verstecken
        if (endPanel != null)
            endPanel.SetActive(false);

        // Alle Math-Bricks zählen (alle Objekte mit Script MathBrickHit)
        totalMathBricks = FindObjectsOfType<MathBrickHit>().Length;
        destroyedMathBricks = 0;

        Debug.Log("Math bricks at start: " + totalMathBricks);
    }

    // Wird aufgerufen, wenn ein Math-Brick zerstört wurde
    public void OnMathBrickDestroyed()
    {
        destroyedMathBricks++;
        Debug.Log("Math brick destroyed. Left: " + (totalMathBricks - destroyedMathBricks));

        if (destroyedMathBricks >= totalMathBricks && totalMathBricks > 0)
        {
            ShowEndScreen();
        }
    }

    private void ShowEndScreen()
    {
        // Spiel pausieren
        Time.timeScale = 0f;

        // Popup anzeigen
        if (endPanel != null)
            endPanel.SetActive(true);
    }

    // Diese Funktion benutzen wir für den "Next Level"-Button
    public void OnNextLevelButton()
    {
        Time.timeScale = 1f;

        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextIndex);
    }
}
