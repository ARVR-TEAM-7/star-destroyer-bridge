using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathStarFiringSounds : MonoBehaviour
{
    public AudioSource activatingSound;
    public AudioSource firingSound;
    public AudioSource deactivatingSound;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FiringSequence());
    }

    IEnumerator FiringSequence()
    {
        // Death Star fires at 13 seconds after scene start
        // activating sound is 10 seconds long
        // TODO loop?
        yield return new WaitForSeconds(3);
        activatingSound.PlayOneShot(activatingSound.clip, 1f);

        yield return new WaitForSeconds(10);
        firingSound.PlayOneShot(firingSound.clip, 1f);

        deactivatingSound.PlayOneShot(deactivatingSound.clip, 1f);
    }
}
