using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioSource leftSound;
    public AudioSource rightSound;
    public AudioSource frontSound;
    public AudioSource rearSound;

    public void PlaySound()
    {
        StartCoroutine(TestSounds());
    }

    IEnumerator TestSounds()
    {
        leftSound.PlayOneShot(leftSound.clip, 1f);
        yield return new WaitForSeconds(2);
        rightSound.PlayOneShot(rightSound.clip, 1f);
        yield return new WaitForSeconds(2);
        frontSound.PlayOneShot(frontSound.clip, 1f);
        yield return new WaitForSeconds(2);
        rearSound.PlayOneShot(rearSound.clip, 1f);
        yield break;
    }
}
