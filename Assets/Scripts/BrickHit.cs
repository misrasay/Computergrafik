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
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        int number = brickNumber.Number;
        bool isCorrect = (number == EquationAnswer.currentAnswer);


        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;

        GenerateEquation equation = FindObjectOfType<GenerateEquation>();
        if (equation != null)
        {
            equation.OnAnswerSelected(isCorrect);
        }


        Destroy(gameObject);
    }
}
