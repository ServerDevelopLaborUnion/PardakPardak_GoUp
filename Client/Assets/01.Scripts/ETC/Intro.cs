using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public AudioSource audioSource;
    public void Sound()
    {
        AudioManager.Instance.PlayAudio("찰박",audioSource);
    }
}
