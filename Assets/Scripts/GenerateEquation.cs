using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateEquation : MonoBehaviour
{
    [SerializeField] private TMP_Text bubbleText;
    [SerializeField] private Animator headAnimator;

    [SerializeField] private List<BrickNumber> answerBricks;

    [SerializeField] private int wrongAnswerOffsetRange = 10;
    [SerializeField] private float resultDisplayTime = 1.2f;

    private void Start()
    {
        AnswerModeState.IsAnswerMode = false;
        AnswerModeState.HasBouncedOffPaddle = false;

        HideAnswerBricks();
        bubbleText.text = "Hit a math brick to show the next equation!";
    }

    public void ShowEquation()
    {
        AnswerModeState.IsAnswerMode = true;
        AnswerModeState.HasBouncedOffPaddle = false;

        headAnimator.SetTrigger("talking");

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int maxInclusive;

        switch (sceneIndex)
        {
            case 1: maxInclusive = 9; break;
            case 2: maxInclusive = 50; break;
            case 3: maxInclusive = 100; break;
            default: maxInclusive = 9; break;
        }

        int a = Random.Range(0, maxInclusive + 1);
        int b = Random.Range(0, maxInclusive + 1);

        int result;
        string opSymbol;

        switch (GameModeManager.CurrentMode)
        {
            case GameMode.Addition:
                opSymbol = "+";
                result = a + b;
                break;

            case GameMode.Subtraction:
                opSymbol = "-";

                if (b > a)
                {
                    int tmp = a;
                    a = b;
                    b = tmp;
                }

                result = a - b;
                break;

            case GameMode.Multiplication:
                opSymbol = "×";
                result = a * b;
                break;

            default:
                opSymbol = "+";
                result = a + b;
                break;
        }

        EquationAnswer.currentAnswer = result;

        AssignAnswersToBricks(result);
        ShowAnswerBricks();

        bubbleText.text = $"The next equation is \n{a} {opSymbol} {b} = ?";
    }

    private void AssignAnswersToBricks(int correctAnswer)
    {
        if (answerBricks == null || answerBricks.Count < 3)
        {
            Debug.LogError("GenerateEquation: Need at least 3 answer bricks assigned!");
            return;
        }

        int correctIndex = Random.Range(0, answerBricks.Count);
        HashSet<int> used = new HashSet<int> { correctAnswer };

        for (int i = 0; i < answerBricks.Count; i++)
        {
            if (i == correctIndex)
            {
                answerBricks[i].SetNumber(correctAnswer);
            }
            else
            {
                int minValue = Mathf.Max(0, correctAnswer - wrongAnswerOffsetRange);
                int maxValue = correctAnswer + wrongAnswerOffsetRange;

                int wrong;
                do
                {
                    wrong = Random.Range(minValue, maxValue + 1);
                }
                while (used.Contains(wrong));

                used.Add(wrong);
                answerBricks[i].SetNumber(wrong);
            }
        }
    }

    private void ShowAnswerBricks()
    {
        foreach (var brick in answerBricks)
        {
            if (brick == null) continue;

            var go = brick.gameObject;
            go.SetActive(true);

            var hit = go.GetComponent<AnswerBrickHit>();
            if (hit != null)
                hit.ResetForNewQuestion(); 
        }
    }


    private void HideAnswerBricks()
    {
        foreach (var brick in answerBricks)
        {
            if (brick == null) continue;
            brick.gameObject.SetActive(false);
        }
    }

    public void OnAnswerSelected(bool isCorrect)
    {
        if (!AnswerModeState.IsAnswerMode)
            return;

        AnswerModeState.IsAnswerMode = false;

        StopAllCoroutines();
        StartCoroutine(ShowResultThenExitAnswerMode(isCorrect));
    }

    private IEnumerator ShowResultThenExitAnswerMode(bool isCorrect)
    {
        bubbleText.text = isCorrect ? "Correct!" : "False!";
        headAnimator.SetTrigger("talking");

        yield return new WaitForSeconds(resultDisplayTime);

        HideAnswerBricks();
        bubbleText.text = "Hit a math brick to show the next equation!";
    }
}
