using UnityEngine;

public class AnswerSFX : MonoBehaviour
{
    public static AnswerSFX Instance;

    [Header("General Audio Source")]
    public AudioSource audioSource;

    [Header("Answer Sounds")]
    public AudioClip correctClip;
    public AudioClip wrongClip;

    [Header("Gameplay Sounds")]
    public AudioClip paddleHitClip;
    public AudioClip wallHitClip;
    
    [Header("Brick Sounds")]
    public AudioClip brickHitClip;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayCorrect()
    {
        if (audioSource != null && correctClip != null)
        {
            audioSource.PlayOneShot(correctClip);
        }
    }

    public void PlayWrong()
    {
        if (audioSource != null && wrongClip != null)
        {
            audioSource.PlayOneShot(wrongClip);
        }
    }

    public void PlayPaddleHit()
    {
        if (audioSource != null && paddleHitClip != null)
        {
            audioSource.PlayOneShot(paddleHitClip);
        }
    }

    public void PlayWallHit()
    {
        if (audioSource != null && wallHitClip != null)
        {
            audioSource.PlayOneShot(wallHitClip);
        }
    }

    public void PlayBrickHit()
    {
        if (audioSource != null && brickHitClip != null)
        {
            audioSource.PlayOneShot(brickHitClip);
        }
    }
}
