using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float[] transitionTimes;
    [SerializeField] private AudioSource[] flyingSounds;
    [SerializeField] private int[] indicesToPlaySound; // the position index at which to play the sound

    private Transform currentWaypoint;
    private Transform nextWaypoint;
    private int waypointIndex = 0;
    private int audioIndex = 0;

    void OnEnable()
    {
        ResetTransform();
        currentWaypoint = waypoints[0];
        nextWaypoint = waypoints[1];
        StartCoroutine(TransitionToWaypoint());
    }

    private void ResetTransform()
    {
        waypointIndex = 0;
        transform.localPosition = waypoints[0].localPosition;
        transform.localRotation = waypoints[0].localRotation;
    }

    private IEnumerator TransitionToWaypoint()
    {
        while(true)
        {
            float transitionStartTime = Time.time;

            while (Time.time - transitionStartTime < transitionTimes[waypointIndex])
            {
                float time = (Time.time - transitionStartTime) / transitionTimes[waypointIndex];
                transform.localPosition = Vector3.Lerp(currentWaypoint.localPosition, nextWaypoint.localPosition, time);
                transform.localRotation = Quaternion.Slerp(currentWaypoint.localRotation, nextWaypoint.localRotation, time);
                yield return null;
            }

            waypointIndex++;

            if (waypointIndex == indicesToPlaySound[audioIndex])
            {
                flyingSounds[audioIndex].PlayOneShot(flyingSounds[audioIndex].clip, 1f);
                if (audioIndex < indicesToPlaySound.Length - 1)
                {
                  audioIndex++;
                }
            }

            if (waypointIndex >= waypoints.Length - 1)
            {
                yield break;
            }

            currentWaypoint = waypoints[waypointIndex];
            nextWaypoint = waypoints[waypointIndex + 1];
        }
    }
}
