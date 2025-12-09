using UnityEngine;

public class WallHitSFX : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        // 🔊 WALL SOUND ABSPIELEN
        if (AnswerSFX.Instance != null)
        {
            AnswerSFX.Instance.PlayWallHit();
        }
    }
}
