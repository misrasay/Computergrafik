using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUnlocker : MonoBehaviour
{
    public GameObject endPanel;

    private int totalMathBricks;
    private int destroyedMathBricks;

    private void Start()
    {

        if (endPanel != null)
            endPanel.SetActive(false);


        totalMathBricks = FindObjectsOfType<MathBrickHit>().Length;
        destroyedMathBricks = 0;

        Debug.Log("Math bricks at start: " + totalMathBricks);
    }


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
    if (HighscoreManager.Instance != null && ScoreManager.Instance != null)
    {
        string playerName = PlayerPrefs.GetString("PlayerName", "Player");
        int score = ScoreManager.Instance.GetScore();


        string operation = GameModeManager.CurrentMode.ToString();


        string levelName = SceneManager.GetActiveScene().name;


        HighscoreManager.Instance.AddHighscore(playerName, score, operation, levelName);

        int maxQ = ScoreManager.Instance.maxQuestions;
        float percent = (score / (float)maxQ) * 100f;
        Debug.Log($"Highscore gespeichert: {playerName} — {score}/{maxQ} ({percent:0}%) [{operation}] in {levelName}");
    }
    else
    {
        Debug.LogWarning("Highscore konnte nicht gespeichert werden: Manager fehlt.");
    }

    UnlockNextLevel();
    StartCoroutine(ShowEndScreenDelayed());

    }

    private void UnlockNextLevel()
    {

        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;

        switch (currentBuildIndex)
        {
            case 1:
                PlayerPrefs.SetInt("Level2", 1);
                break;

            case 2:
                PlayerPrefs.SetInt("Level3", 1);
                break;
        }

        PlayerPrefs.Save();
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

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(0);
        }

        int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextIndex);
    }
}
