using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public class StarDestroyerShoot : MonoBehaviour
{
    private ParticleSystem emitter;
    public AudioSource sound;
    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     emitter = GetComponent<ParticleSystem>();
    //     // Shoot();
    // }

    public void Shoot()
    {
        emitter = GetComponent<ParticleSystem>();
        sound.Play();
        emitter.Emit(1);
        // Task.Delay(200);
        // emitter.Emit(1);

    }
}
