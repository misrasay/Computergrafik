using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameUI : MonoBehaviour
{
    public GameObject popup;
    public TMP_InputField nameInput;
    public GameObject enterNameButton;
    public TMP_Text playerNameDisplay; 

    private const string PLAYER_NAME_KEY = "PlayerName";

    private void Start()
    {
        string savedName = PlayerPrefs.GetString(PLAYER_NAME_KEY, "");

        if (string.IsNullOrEmpty(savedName))
        {
            popup.SetActive(false);
            enterNameButton.SetActive(true);
            playerNameDisplay.gameObject.SetActive(false);
        }
        else
        {
            popup.SetActive(false);
            enterNameButton.SetActive(false);

            playerNameDisplay.text = savedName;
            playerNameDisplay.gameObject.SetActive(true);
        }
    }

    public void OnSaveName()
    {
        string newName = nameInput.text.Trim();
        if (string.IsNullOrEmpty(newName)) return;

        PlayerPrefs.SetString(PLAYER_NAME_KEY, newName);
        PlayerPrefs.Save();

        popup.SetActive(false);
        enterNameButton.SetActive(false);

        playerNameDisplay.text = newName;
        playerNameDisplay.gameObject.SetActive(true);
    }

    public void OpenPopup()
    {
        popup.SetActive(true);
    }
}
