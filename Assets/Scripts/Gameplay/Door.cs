using System.Collections;
using System.Collections.Generic;
using GameEnum;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;
    private AudioSource doorAudioSouce;
    [SerializeField] private AudioClip[] doorAudio;
    private BoxCollider _boxCollider;
    [SerializeField] private GameObject ending;
    [SerializeField] private GameObject _door;
    
    private Transform _doorTransform;
    public keyType _doorType;
    public bool isUnlocked=false;
    
    private void Start()
    {
        this.doorAudioSouce = this.GetComponent<AudioSource>();
        _doorTransform = this._door.GetComponent<Transform>();
    }
    public void ToggleDoor()
    {
        // Toggle the door's state (open or closed)

        if (isUnlocked)
        {
            isOpen = !isOpen;
            if (isOpen == true)
            {
                this.doorAudioSouce.clip = doorAudio[0];
                // _boxCollider.isTrigger = true;
                OpenCloseDoor();
            }
            else
            {
                this.doorAudioSouce.clip = doorAudio[1];
                OpenCloseDoor();
                //_boxCollider.isTrigger = false;
            }
            this.doorAudioSouce.Play();
            //   doorAnimator.SetBool("IsDoorActive", isOpen);
        }

    }

    private void OpenCloseDoor()
    {
        if (isOpen)
        {
            Debug.Log("opening");
            _doorTransform.Rotate(0,90f,0);
        }
        else
        {
            Debug.Log("Closing");
            _doorTransform.Rotate(0,-90,0);
        }

    }

    public void UnlockDoor()
    {
        isUnlocked = true;

    }

}
