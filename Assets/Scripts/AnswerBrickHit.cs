using UnityEngine;

public class AnswerBrickHit : MonoBehaviour
{
    private BrickNumber brickNumber;
    private Collider col;

    private void Awake()
    {
        brickNumber = GetComponent<BrickNumber>();
        col = GetComponent<Collider>();
    }

    public void ArmForNewQuestion()
    {
        if (col != null)
            col.enabled = false; 
    }

    public void EnableAfterPaddleBounce()
    {
        if (col != null)
            col.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        if (!AnswerModeState.IsAnswerMode || !AnswerModeState.HasBouncedOffPaddle)
            return;

        int number = brickNumber.Number;
        bool isCorrect = (number == EquationAnswer.currentAnswer);

        var eq = FindObjectOfType<GenerateEquation>();
        if (eq != null)
            eq.OnAnswerSelected(isCorrect);
    }
}
