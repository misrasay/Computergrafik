using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class HighscoreListUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreListText;
    [SerializeField] private int maxEntries = 10;      // wie viele angezeigt werden (Top 10)

    [Header("Optionale Filter")]
    [SerializeField] private string modeFilter = "";   // z.B. "Addition", "Subtraction" ...
    [SerializeField] private string levelFilter = "";  // z.B. "MB_Level1", "MB_Level2", "MB_Level3"

    private void OnEnable()
    {
        RefreshList();
    }

    public void RefreshList()
    {
        if (scoreListText == null)
        {
            Debug.LogWarning("HighscoreListUI: scoreListText is not assigned.");
            return;
        }

        if (HighscoreManager.Instance == null ||
            HighscoreManager.Instance.highscoreList == null)
        {
            scoreListText.text = "No highscores yet.";
            return;
        }

        List<HighscoreEntry> list = HighscoreManager.Instance.highscoreList;

        // --- Nach Operation & Level filtern ---
        List<HighscoreEntry> filtered = new List<HighscoreEntry>();
        foreach (var entry in list)
        {
            // optionaler Filter nach Operation (Addition, ...)
            if (!string.IsNullOrEmpty(modeFilter) && entry.gameMode != modeFilter)
                continue;

            // Filter nach Level-Name (Scene-Name)
            if (!string.IsNullOrEmpty(levelFilter) && entry.levelName != levelFilter)
                continue;

            filtered.Add(entry);
        }

        if (filtered.Count == 0)
        {
            scoreListText.text = "No highscores yet.";
            return;
        }

        // nach Score sortieren (beste zuerst)
        filtered.Sort((a, b) => b.score.CompareTo(a.score));

        StringBuilder sb = new StringBuilder();

        int count = Mathf.Min(maxEntries, filtered.Count);

        for (int i = 0; i < count; i++)
        {
            HighscoreEntry e = filtered[i];

            float percent = (e.score / 5f) * 100f;

            // Operation bleibt sichtbar!
            sb.AppendLine($"{i + 1}. {e.playerName} — {e.score}/5 ({percent:0}%) [{e.gameMode}]");
        }

        scoreListText.text = sb.ToString();
    }

    // Diese Funktion wird von deinen Level-Buttons aufgerufen.
    // Parameter ist jetzt der LEVEL-Name (z.B. "MB_Level1").
    public void SetFilter(string levelName)
    {
        levelFilter = levelName;
        RefreshList();
    }
}
