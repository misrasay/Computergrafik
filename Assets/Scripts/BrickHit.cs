using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickHit : MonoBehaviour
{
    private BrickNumber brickNumber;
    private Animator anim;

    [Tooltip("Wie lange der Brick nach dem Hit noch existiert, damit die Animation ablaufen kann.")]
    public float destroyDelay = 0.6f;

    void Awake()
    {
        brickNumber = GetComponent<BrickNumber>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        int number = brickNumber.Number;
        bool isCorrect = (number == EquationAnswer.currentAnswer);

        if (anim != null)
        {
            if (isCorrect)
                anim.SetTrigger("HitCorrect");
            else
                anim.SetTrigger("HitWrong");
        }

        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;

        GenerateEquation equation = FindObjectOfType<GenerateEquation>();
        if (equation != null)
        {
            equation.OnBrickHit(isCorrect);
        }


        Destroy(gameObject, destroyDelay);
    }
}
