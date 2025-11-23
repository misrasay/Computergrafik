using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreButtonHandler : MonoBehaviour
{

    [SerializeField] GameObject levelOneActive;
    [SerializeField] GameObject levelTwoActive;
    [SerializeField] GameObject levelThreeActive;


    void OnEnable()
    {

        levelOneActive.SetActive(true);
        levelTwoActive.SetActive(false);
        levelThreeActive.SetActive(false);

        
    }

    public void SetLevel1Active()
    {
        levelOneActive.SetActive(true);
        levelTwoActive.SetActive(false);
        levelThreeActive.SetActive(false);

    }

    public void SetLevel2Active()

    {
        levelOneActive.SetActive(false);
        levelTwoActive.SetActive(true);
        levelThreeActive.SetActive(false);
    }

    public void SetLevel3Active()

    {
        levelOneActive.SetActive(false);
        levelTwoActive.SetActive(false);
        levelThreeActive.SetActive(true);
    }
}
