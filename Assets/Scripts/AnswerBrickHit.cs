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

    // Neu: Referenz auf LevelUnlocker
    private LevelUnlocker levelUnlocker;

    private void Awake()
    {
        col = GetComponent<Collider>();

        if (brickNumber == null)
            brickNumber = GetComponent<BrickNumber>();

        if (col != null)
            col.enabled = false;

        ResetForNewQuestion();

        // LevelUnlocker in der Scene suchen
        levelUnlocker = FindObjectOfType<LevelUnlocker>();
    }


    public void ResetForNewQuestion()
    {
        hasBeenAnswered = false;

        if (col != null)
            col.enabled = false;

        if (correctHit != null) correctHit.SetActive(true);
        if (wrongHit != null) wrongHit.SetActive(true);

        if (correctTimeline != null)
        {
            correctTimeline.time = 0;
            correctTimeline.Stop();
            correctTimeline.Evaluate();
        }

        if (wrongTimeline != null)
        {
            wrongTimeline.time = 0;
            wrongTimeline.Stop();
            wrongTimeline.Evaluate();
        }
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

        // NEU: Hier sagen wir dem LevelUnlocker,
        // dass eine Aufgabe (zu einem Math-Brick) beantwortet wurde
        if (levelUnlocker != null)
        {
            levelUnlocker.OnMathBrickDestroyed();
        }
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
