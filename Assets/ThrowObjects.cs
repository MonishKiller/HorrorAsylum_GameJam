using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ThrowObjects : MonoBehaviour
{
    private AudioSource _playerMainSource;
    private GameObject objectToThrow;
    public float throwForce = 10f;

    private void Start()
    {
        objectToThrow = this.gameObject;
        _playerMainSource = this.gameObject.GetComponentInParent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            ThrowRandom();
    }

    void ThrowRandom()
    {
        if (objectToThrow != null)
        {
            _playerMainSource.Play();
            // Generate a random direction
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 1f), Random.Range(-1f, 1f)).normalized;

            // Apply force to the object in the random direction
            objectToThrow.GetComponent<Rigidbody>().AddForce(randomDirection * throwForce, ForceMode.Impulse);
        }
    }
}
