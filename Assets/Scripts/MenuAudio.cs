using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour
{

    [SerializeField] private AudioSource clickSound;

    public void PlayClickSound()
    {

        clickSound.Play();

    }
}
