using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTest : MonoBehaviour
{
    public void PlaySound(AudioSource soundToPlay)
    {
        soundToPlay.PlayOneShot(soundToPlay.clip, 1f);
    }
}
