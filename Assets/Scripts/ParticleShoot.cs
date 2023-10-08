using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ParticleShoot : MonoBehaviour
{
    private ParticleSystem emitter;
    public AudioSource sound;

    private void Awake()
    {
        emitter = GetComponent<ParticleSystem>();
    }
    /*void OnEnable()
    {
        Shoot();
    }*/
    public async void Shoot()
    {
        if (sound != null)
            sound.Play();

        emitter.Emit(1);
        await Task.Delay(200);
        emitter.Emit(1);

    }
}
