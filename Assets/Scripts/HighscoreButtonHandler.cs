using UnityEngine;

public class HighscoreButtonHandler : MonoBehaviour
{
    [Header("Tab-Grafiken")]
    [SerializeField] private GameObject levelOneActive;
    [SerializeField] private GameObject levelTwoActive;
    [SerializeField] private GameObject levelThreeActive;

    [Header("Referenz auf die Highscore-Liste")]
    [SerializeField] private HighscoreListUI highscoreUI;

    [Header("Szenen-Namen für die Filter")]
    [SerializeField] private string levelOneSceneName = "LevelOne";
    [SerializeField] private string levelTwoSceneName = "LevelTwo";
    [SerializeField] private string levelThreeSceneName = "LevelThree";

    private void OnEnable()
    {
        SetLevel1Active();   // Standard: Level 1
    }

    public void SetLevel1Active()
    {
        SetActiveTab(1);

        if (highscoreUI != null)
            highscoreUI.SetFilter(levelOneSceneName);
    }

    public void SetLevel2Active()
    {
        SetActiveTab(2);

        if (highscoreUI != null)
            highscoreUI.SetFilter(levelTwoSceneName);
    }

    public void SetLevel3Active()
    {
        SetActiveTab(3);

        if (highscoreUI != null)
            highscoreUI.SetFilter(levelThreeSceneName);
    }

    private void SetActiveTab(int tab)
    {
        if (levelOneActive != null)
            levelOneActive.SetActive(tab == 1);

        if (levelTwoActive != null)
            levelTwoActive.SetActive(tab == 2);

        if (levelThreeActive != null)
            levelThreeActive.SetActive(tab == 3);
    }
}
