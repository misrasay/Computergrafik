using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int maxQuestions = 5;
    public int correctAnswers = 0;

    public TMP_Text uiScoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetScore()
    {
        correctAnswers = 0;
        UpdateScoreText();
    }

    public void RegisterCorrectAnswer()
    {
        correctAnswers++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (uiScoreText != null)
        {
            uiScoreText.text = correctAnswers + "/" + maxQuestions;
        }
    }

    public float GetPercentage()
    {
        if (maxQuestions <= 0) return 0f;
        return (float)correctAnswers / maxQuestions * 100f;
    }


    public bool IsGameComplete()
    {
        return correctAnswers >= maxQuestions;
    }


    public int GetScore()
    {
        return correctAnswers;
    }
}
