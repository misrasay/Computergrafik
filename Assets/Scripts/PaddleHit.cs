using UnityEngine;

public class PaddleHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        if (!AnswerModeState.IsAnswerMode)
            return;

        AnswerModeState.HasBouncedOffPaddle = true;

        var answerBricks = FindObjectsOfType<AnswerBrickHit>();
        foreach (var brick in answerBricks)
        {
            brick.EnableAfterPaddleBounce();
        }
    }
}
