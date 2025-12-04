using UnityEngine;

public class MathBrickHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        if (AnswerModeState.IsAnswerMode)
            return;

        GenerateEquation equation = FindObjectOfType<GenerateEquation>();
        if (equation != null)
        {
            equation.ShowEquation();
        }

        // Kein LevelUnlocker-Aufruf hier!
        Destroy(gameObject);
    }
}
