using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUnlocker : MonoBehaviour
{

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
        StartCoroutine(ShowEndScreenDelayed());
    }

    private System.Collections.IEnumerator ShowEndScreenDelayed()
    {
        yield return new WaitForSeconds(1f);

        Time.timeScale = 0f;

        if (endPanel != null)
            endPanel.SetActive(true);
    }


    public void OnNextLevelButton()
    {

        Time.timeScale = 1f;

        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }

        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextIndex);
    }
}
