using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioClip soundClip; 
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Hit");
        //AudioSource.PlayClipAtPoint(soundClip, other.transform.position);

        List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();        
        GetComponent<ParticleSystem>().GetCollisionEvents(other, collisionEvents);        
        foreach (ParticleCollisionEvent evt in collisionEvents) {             
            // Handle each collision event, e.g., get the collision position
            Vector3 collisionPosition = evt.intersection;
            AudioSource.PlayClipAtPoint(soundClip, collisionPosition);
        }       
    }
}
