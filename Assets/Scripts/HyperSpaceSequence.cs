using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HyperSpaceSequence : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform hyperSpace;
    public Transform entryParticles;
    public Vector3 entryPosition;
    public Vector3 activePosition;
    public Vector3 exitPosition;

    public Vector3 entrySize;
    public Vector3 activeSize;
    public Vector3 exitSize;

    private Vector3 targetPosition;
    private Vector3 targetSize;
    private void OnEnable()
    {
        Sequence();
    }

    private async void Sequence()
    {
        hyperSpace.localPosition = entryPosition;
        hyperSpace.localScale = entrySize;

        targetPosition = entryPosition;
        targetSize = entrySize;

        await Task.Delay(2000);
        targetPosition = activePosition;
        targetSize = activeSize;

        await Task.Delay(8000);
        targetPosition = exitPosition;
        targetSize = exitSize;
    }

    private void Update()
    {
        hyperSpace.localPosition = Vector3.Lerp(hyperSpace.localPosition, targetPosition, Time.deltaTime * 10f);
        hyperSpace.localScale = Vector3.Lerp(hyperSpace.localScale, targetSize, Time.deltaTime * 5f);
    }
}
