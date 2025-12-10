using UnityEngine;

public class MathBrickHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        if (AnswerModeState.IsAnswerMode)
            return;

        CameraShake.Instance.Shake(0.15f, 0.25f);

        GenerateEquation equation = FindObjectOfType<GenerateEquation>();
        if (equation != null)
        {
            equation.ShowEquation();
        }

        Destroy(gameObject);
    }
}
