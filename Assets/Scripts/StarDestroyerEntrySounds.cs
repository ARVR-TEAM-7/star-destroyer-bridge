using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarDestroyerEntrySounds : MonoBehaviour
{
    public AudioSource exitHyperspace1;
    public AudioSource exitHyperspace2;
    public AudioSource exitHyperspace3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EntrySequence());
    }

    IEnumerator EntrySequence()
    {
        yield return new WaitForSeconds(1.2f);
        exitHyperspace1.PlayOneShot(exitHyperspace1.clip, 1f);

        yield return new WaitForSeconds(1.2f);
        exitHyperspace2.PlayOneShot(exitHyperspace2.clip, 1f);

        yield return new WaitForSeconds(0.8f);
        exitHyperspace3.PlayOneShot(exitHyperspace3.clip, 1f);
    }
}
