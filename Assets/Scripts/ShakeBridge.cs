using UnityEngine;
using System.Collections;

public class ShakeBridge : MonoBehaviour
{
  	private Vector3 _startPos;
  	private float _timer;
  	private Vector3 _randomPos;

  	public float _time = 0.2f;
  	public float _distance = 0.1f;
  	public float _delayBetweenShakes = 0f;
    public AudioSource explosionSound;
    public AudioSource shipAlarmSound;

  	private void Awake()
  	{
  		  _startPos = transform.position;
  	}

  	private void OnValidate()
  	{
    		if (_delayBetweenShakes > _time)
    			 _delayBetweenShakes = _time;
  	}

  	public void Begin()
  	{
        explosionSound.PlayOneShot(explosionSound.clip, 1f);
        shipAlarmSound.PlayOneShot(shipAlarmSound.clip, 1f);
    		StopAllCoroutines();
    		StartCoroutine(Shake());
  	}

  	private IEnumerator Shake()
  	{
		    _timer = 0f;

    		while (_timer < _time)
    		{
      			_timer += Time.deltaTime;

      			_randomPos = _startPos + (Random.insideUnitSphere * _distance);

      			transform.position = _randomPos;

      			if (_delayBetweenShakes > 0f)
      			{
      			    yield return new WaitForSeconds(_delayBetweenShakes);
      			}
      			else
      			{
      				   yield return null;
      			}
    		}

    	  transform.position = _startPos;
    	}
}
