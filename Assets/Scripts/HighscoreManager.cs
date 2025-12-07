using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class HighscoreEntry
{
    public string playerName;
    public int score;

    // Operation (Addition, Subtraction, Multiplication)
    public string gameMode;

    // Level-Name (z. B. LevelOne, LevelTwo, LevelThree)
    public string levelName;
}

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;

    private const string HighscoreKey = "Highscores";
    public List<HighscoreEntry> highscoreList = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadHighscores();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddHighscore(string name, int score, string mode, string levelName)
    {
        HighscoreEntry entry = new HighscoreEntry
        {
            playerName = name,
            score = score,
            gameMode = mode,      // Operation
            levelName = levelName // Level
        };

        highscoreList.Add(entry);
        SortHighscores();
        SaveHighscores();
    }

    private void SortHighscores()
    {
        // global nach Score sortieren (beste zuerst)
        highscoreList.Sort((a, b) => b.score.CompareTo(a.score));
    }

    private void SaveHighscores()
    {
        string json = JsonUtility.ToJson(new HighscoreListWrapper(highscoreList));
        PlayerPrefs.SetString(HighscoreKey, json);
        PlayerPrefs.Save();
    }

    private void LoadHighscores()
    {
        if (PlayerPrefs.HasKey(HighscoreKey))
        {
            string json = PlayerPrefs.GetString(HighscoreKey);
            HighscoreListWrapper wrapper =
                JsonUtility.FromJson<HighscoreListWrapper>(json);

            highscoreList = wrapper.list;
        }
    }

    [System.Serializable]
    private class HighscoreListWrapper
    {
        public List<HighscoreEntry> list;
        public HighscoreListWrapper(List<HighscoreEntry> list)
        {
            this.list = list;
        }
    }
}
