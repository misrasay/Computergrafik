using UnityEngine;
using UnityEngine.Playables;

public class AnswerBrickHit : MonoBehaviour
{
    [SerializeField] private BrickNumber brickNumber;

    [SerializeField] private GameObject correctHit;
    [SerializeField] private GameObject wrongHit;

    [SerializeField] private PlayableDirector correctTimeline;
    [SerializeField] private PlayableDirector wrongTimeline;

    private Collider col;

    private void Awake()
    {
        col = GetComponent<Collider>();

        ResetVisuals();
    }

    public void ArmForNewQuestion()
    {
        if (col != null)
            col.enabled = false;

        ResetVisuals();
    }

    private void ResetVisuals()
    {
        if (correctHit != null) correctHit.SetActive(true);
        if (wrongHit != null) wrongHit.SetActive(true);
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

        bool isCorrect = (brickNumber.Number == EquationAnswer.currentAnswer);

        PlayHitVisual(isCorrect);

        FindObjectOfType<GenerateEquation>()?.OnAnswerSelected(isCorrect);
    }

    private void PlayHitVisual(bool isCorrect)
    {
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
