using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float[] transitionTimes;
    [SerializeField] private AudioSource flyingSound;
    [SerializeField] private int indexToPlaySound; // the position index at which to play the sound

    private Transform currentWaypoint;
    private Transform nextWaypoint;
    private int index = 0;

    void Start()
    {
        currentWaypoint = waypoints[0];
        nextWaypoint = waypoints[1];
        StartCoroutine(TransitionToWaypoint());
    }

    private IEnumerator TransitionToWaypoint()
    {
        float transitionStartTime = Time.time;

        while (Time.time - transitionStartTime < transitionTimes[index])
        {
            float time = (Time.time - transitionStartTime) / transitionTimes[index];
            transform.localPosition = Vector3.Lerp(currentWaypoint.localPosition, nextWaypoint.localPosition, time);
            transform.localRotation = Quaternion.Slerp(currentWaypoint.localRotation, nextWaypoint.localRotation, time);
            yield return null;
        }

        transform.localPosition = nextWaypoint.localPosition;
        transform.localRotation = nextWaypoint.localRotation;

        index++;

        if (index == indexToPlaySound)
        {
            flyingSound.PlayOneShot(flyingSound.clip, 1f);
        }

        if (index >= waypoints.Length - 1)
        {
            yield break;
        }

        currentWaypoint = waypoints[index];
        nextWaypoint = waypoints[index + 1];

        StartCoroutine(TransitionToWaypoint());
    }
}
