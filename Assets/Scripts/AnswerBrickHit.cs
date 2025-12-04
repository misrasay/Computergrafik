using UnityEngine;
using UnityEngine.Playables;

public class AnswerBrickHit : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BrickNumber brickNumber;

    [Header("Visuals (Alembic Roots)")]
    [SerializeField] private GameObject correctHit;
    [SerializeField] private GameObject wrongHit;

    [Header("Timelines")]
    [SerializeField] private PlayableDirector correctTimeline;
    [SerializeField] private PlayableDirector wrongTimeline;

    private Collider col;
    private bool hasBeenAnswered = false;

    private void Awake()
    {
        col = GetComponent<Collider>();

        if (brickNumber == null)
            brickNumber = GetComponent<BrickNumber>();

        if (col != null)
            col.enabled = false;

        ResetVisuals();
    }

    private void ResetVisuals()
    {
        hasBeenAnswered = false;

        if (correctHit != null) correctHit.SetActive(true);
        if (wrongHit != null) wrongHit.SetActive(true);
    }


    public void EnableAfterPaddleBounce()
    {
        if (hasBeenAnswered)
            return;

        if (col != null)
            col.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        if (!AnswerModeState.IsAnswerMode || !AnswerModeState.HasBouncedOffPaddle)
            return;

        if (hasBeenAnswered)
            return;

        bool isCorrect = (brickNumber != null &&
                          brickNumber.Number == EquationAnswer.currentAnswer);

        PlayHitVisual(isCorrect);

        var eq = FindObjectOfType<GenerateEquation>();
        if (eq != null)
            eq.OnAnswerSelected(isCorrect);
    }

    private void PlayHitVisual(bool isCorrect)
    {
        hasBeenAnswered = true;

        if (col != null)
            col.enabled = false;

        if (isCorrect)
        {
            if (wrongHit != null) wrongHit.SetActive(false);
            if (correctTimeline != null) correctTimeline.Play();
        }
        else
        {
            if (correctHit != null) correctHit.SetActive(false);
            if (wrongTimeline != null) wrongTimeline.Play();
        }
    }
}
