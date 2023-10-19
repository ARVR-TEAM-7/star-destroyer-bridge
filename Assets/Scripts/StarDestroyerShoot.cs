using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public class StarDestroyerShoot : MonoBehaviour
{
    private ParticleSystem emitter;
    public AudioSource sound;
    [SerializeField]
    public GameObject target;
    public bool isShooting = false;
    public int burst = 0;
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

    public async void Shoot()
    {
      for (int i = 0; i < 3; i++) {
        emitter = GetComponent<ParticleSystem>();
        sound.Play();
        // Calculate direction to the target
        Vector3 targetDirection = target.transform.position - transform.position;
        // rotate emitter to face the target
        emitter.transform.rotation = Quaternion.LookRotation(targetDirection);
        emitter.Emit(1);
        await Task.Delay(175);
      }
        // Task.Delay(200);
        // emitter.Emit(1);
    }
}
