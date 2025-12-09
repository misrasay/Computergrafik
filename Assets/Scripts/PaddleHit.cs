using UnityEngine;

public class PaddleHit : MonoBehaviour
{
    [SerializeField] private GameObject hintText;
    private float pulseScale = 0.1f;
    private float pulseSpeed = 2f;

    private float timeSinceLastHit = 0f;
    private float timeToShow = 10f;

    private void Start()
    {
        hintText.SetActive(false);
        hintText.transform.localScale = Vector3.one;
    }

    private void OnCollisionEnter(Collision collision)
    {
        timeSinceLastHit = 0f;

        if (hintText.activeSelf == true)
        {
            hintText.SetActive(false);
        }

        // Wenn kein Ball → zurück
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        // 🔊 PADDLE SOUND ABSPIELEN
        if (AnswerSFX.Instance != null)
        {
            AnswerSFX.Instance.PlayPaddleHit();
        }

        // Wenn nicht im AnswerMode → kein Brick freigeben
        if (!AnswerModeState.IsAnswerMode)
            return;

        AnswerModeState.HasBouncedOffPaddle = true;

        var answerBricks = FindObjectsOfType<AnswerBrickHit>();
        foreach (var brick in answerBricks)
        {
            brick.EnableAfterPaddleBounce();
        }
    }

    private void Update()
    {
        timeSinceLastHit += Time.deltaTime;

        if (timeSinceLastHit >= timeToShow)
        {
            hintText.SetActive(true);

            float pulse = (Mathf.Sin(Time.time * pulseSpeed) + 1f) * 0.5f;
            float scale = 1f + pulse * pulseScale;
            hintText.transform.localScale = Vector3.one * scale;
        }
    }
}
