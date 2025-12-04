using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighscoreShareButton : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;

    public void ShareHighscore()
    {
        var highscores = HighscoreManager.Instance.highscoreList;

        if (highscores == null || highscores.Count == 0)
        {
            if (statusText != null)
                statusText.text = "No highscore to share!";
            Debug.Log("No highscores available to share.");
            return;
        }

        HighscoreEntry best = highscores[0];

        string message = 
            $"🔥 Mental Breakdance Score 🔥\n" +
            $"{best.playerName} got {best.score}/5 in {best.gameMode}! 🧠⚡";

        GUIUtility.systemCopyBuffer = message; // copied to clipboard

        if (statusText != null)
            statusText.text = "Copied to clipboard! 📋";

        Debug.Log("Shared Highscore: " + message);
    }
}

