using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;


public class HighscoreListUI : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreListText;
    [SerializeField] private int maxEntries = 10;
    [SerializeField] private string modeFilter = "";

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


        List<HighscoreEntry> filtered = new List<HighscoreEntry>();
        foreach (var entry in list)
        {
            if (!string.IsNullOrEmpty(modeFilter))
            {
                if (entry.gameMode != modeFilter)
                    continue;
            }
            filtered.Add(entry);
        }

        if (filtered.Count == 0)
        {
            scoreListText.text = "No highscores yet.";
            return;
        }

        filtered.Sort((a, b) => b.score.CompareTo(a.score));

        StringBuilder sb = new StringBuilder();

        int count = Mathf.Min(maxEntries, filtered.Count);
        for (int i = 0; i < count; i++)
        {
            HighscoreEntry e = filtered[i];


            float percent = (e.score / 5f) * 100f;


            sb.AppendLine($"{i + 1}. {e.playerName} — {e.score}/5 ({percent:0}%) [{e.gameMode}]");
        }

        scoreListText.text = sb.ToString();
    }
}
