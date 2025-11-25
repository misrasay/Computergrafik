using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickHit : MonoBehaviour
{

    private BrickNumber brickNumber;

    void Awake()
    {
        brickNumber = GetComponent<BrickNumber>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ball"))
        {

            int number = brickNumber.Number;

            bool isCorrect = (number == EquationAnswer.currentAnswer);

            gameObject.SetActive(false);


            GenerateEquation equation = FindObjectOfType<GenerateEquation>();
            equation.OnBrickHit(isCorrect);

            Destroy(gameObject);
        }
    }
}
