using System;
using UnityEngine;
using TMPro;

public class HighscoreShareButton : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TMP_Text scoreListText;
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private GameObject sharePanel;

    [Header("Optional Header")]
    [TextArea]
    [SerializeField] private string shareHeader = "Mental Breakdance – Highscores";

    private void Start()
    {
        if (sharePanel != null)
            sharePanel.SetActive(false);
    }

    public void OnShareButtonClicked()
    {
        string message = BuildShareMessage();

        if (string.IsNullOrWhiteSpace(message))
        {
            if (statusText != null)
                statusText.text = "No highscores to share yet.";
            return;
        }

        GUIUtility.systemCopyBuffer = message;

        if (statusText != null)
            statusText.text = "Copied! Choose an app below ↓";

        if (sharePanel != null)
            sharePanel.SetActive(true);

        Debug.Log("Prepared share text:\n" + message);
    }


    public void ShareOnWhatsapp()
    {
        string msg = BuildShareMessage();
        string url = "https://wa.me/?text=" + Uri.EscapeDataString(msg);
        Application.OpenURL(url);
    }

    public void ShareOnEmail()
    {
        string subject = "Mental Breakdance – Highscores";
        string body = BuildShareMessage();
        string url = "mailto:?subject=" + Uri.EscapeDataString(subject) +
                     "&body=" + Uri.EscapeDataString(body);
        Application.OpenURL(url);
    }

    public void ShareOnInstagram()
    {
        Application.OpenURL("https://www.instagram.com/");
    }

    public void CloseSharePanel()
    {
        if (sharePanel != null)
            sharePanel.SetActive(false);
    }

    private string BuildShareMessage()
    {
        if (scoreListText == null || string.IsNullOrWhiteSpace(scoreListText.text))
            return string.Empty;

        return shareHeader + "\n" + scoreListText.text;
    }
}
