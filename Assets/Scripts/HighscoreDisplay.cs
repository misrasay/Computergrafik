using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;

    private void Start()
    {
        if (ScoreManager.Instance == null)
        {
            if (resultText != null)
                resultText.text = "No score available.";
            return;
        }

        int correct = ScoreManager.Instance.correctAnswers;
        int total = ScoreManager.Instance.maxQuestions;
        float percent = ScoreManager.Instance.GetPercentage();

        
        if (resultText != null)
        {
            resultText.text = correct + "/" + total + "\n" + percent.ToString("0") + " %";
        }
    }
}

