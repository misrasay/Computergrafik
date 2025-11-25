using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateEquation : MonoBehaviour
{

    [SerializeField] private TMP_Text bubbleText;
    [SerializeField] private Animator headAnimator;


    // Start is called before the first frame update
    void Start()
    {
        Generate();

    }

    public void Generate()

    {
        headAnimator.SetTrigger("talking");

        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        int maxInclusive;

        switch (sceneIndex)
        {
            case 1:
                maxInclusive = 9;
                break;

            case 2:
                maxInclusive = 50;
                break;

            case 3:
                maxInclusive = 100;
                break;

            default:
                maxInclusive = 9;
                break;
        }

        int a = Random.Range(0, maxInclusive + 1);
        int b = Random.Range(0, maxInclusive + 1);

        int result = a + b;

        EquationAnswer.currentAnswer = result;
        BrickNumberManager manager = FindAnyObjectByType<BrickNumberManager>();
        manager.AssignNumbers();


        bubbleText.text = $"The next equation is \n{a} + {b} = ?";
    }

    public void OnBrickHit(bool isCorrect)
    {
        StopAllCoroutines();
        StartCoroutine(ShowResultThenNext(isCorrect));
    }

    private IEnumerator ShowResultThenNext(bool isCorrect)
    {
        if (isCorrect)
            bubbleText.text = "Correct!";
        else
            bubbleText.text = "False!";

        headAnimator.SetTrigger("talking");

        yield return new WaitForSeconds(1.2f);

        Generate();
    }
}
