using UnityEngine;
using TMPro;

public class HighscoreShareButton : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text scoreListText; 
    [SerializeField] private TMP_Text statusText;    

    [Header("Optional Header")]
    [TextArea]
    [SerializeField] private string shareHeader = "Mental Breakdance – Highscores";

    public void ShareHighscore()
    {
        if (scoreListText == null || string.IsNullOrWhiteSpace(scoreListText.text))
        {
            if (statusText != null)
                statusText.text = "No highscores to share!";
            
            Debug.Log("No highscores available to share.");
            return;
        }

        string message = shareHeader + "\n" + scoreListText.text;

        GUIUtility.systemCopyBuffer = message;

        if (statusText != null)
            statusText.text = "Highscores copied to clipboard!";

        Debug.Log("Shared highscores:\n" + message);
    }
}
