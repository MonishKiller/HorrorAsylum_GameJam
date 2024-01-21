using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObjects : MonoBehaviour
{
    public AudioSource _playerMainSource;
    private GameObject objectToDrop;
    private Rigidbody _rigidbody;

    private void Start()
    {
        objectToDrop = this.gameObject;
        _playerMainSource = this.gameObject.GetComponentInParent<AudioSource>();
        _rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }
    public void DropRandom()
    {
        if (objectToDrop != null)
        {
            _rigidbody.isKinematic = false;
            _playerMainSource.Play();
        }
    }
   
}
