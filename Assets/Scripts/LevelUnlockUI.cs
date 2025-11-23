using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlockUI : MonoBehaviour
{

    public GameObject level2Button;
    public GameObject level2Locked;
    public GameObject level3Button;
    public GameObject level3Locked;


    private void OnEnable()
    {

        CheckUnlockedLevels();

    }

    private void CheckUnlockedLevels()
    {

        bool level2Unlocked = PlayerPrefs.GetInt("Level2", 0) == 1;
        bool level3Unlocked = PlayerPrefs.GetInt("Level3", 0) == 1;

        level2Button.SetActive(level2Unlocked);
        level2Locked.SetActive(!level2Unlocked);

        level3Button.SetActive(level3Unlocked);
        level3Locked.SetActive(!level3Unlocked);

    }
}
