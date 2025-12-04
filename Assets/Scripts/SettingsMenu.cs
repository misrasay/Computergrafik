using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel;

    public void ToggleSettings()
    {
        bool active = settingsPanel.activeSelf;
        settingsPanel.SetActive(!active);

        Debug.Log("ToggleSettings – active now: " + settingsPanel.activeSelf);
    }
}
