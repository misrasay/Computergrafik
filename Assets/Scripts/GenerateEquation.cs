using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateEquation : MonoBehaviour
{

    [SerializeField] private TMP_Text bubbleText;

    // Start is called before the first frame update
    void Start()
    {
        Generate();

    }

    private void Generate()
    {
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



        bubbleText.text = $"The next equation is \n{a} + {b} = ?";
    }
}
