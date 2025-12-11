using UnityEngine;

public class NormalBrickHitSFX : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        // Sound abspielen
        if (AnswerSFX.Instance != null)
        {
            AnswerSFX.Instance.PlayBrickHit();
        }
    }
}
