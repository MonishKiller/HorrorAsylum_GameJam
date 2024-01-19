using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isOpen = false;
    private Animator doorAnimator = null;
    private AudioSource doorAudioSouce;
    [SerializeField] private AudioClip[] doorAudio;
    private BoxCollider _boxCollider;
    public Doors _currentDoor;
    [SerializeField] private GameObject ending;

    public enum Doors { corridorDoor, basementDoor, UpperDoor, Other }
    private void Start()
    {
        this.doorAnimator = this.GetComponent<Animator>();
        this.doorAudioSouce = this.GetComponent<AudioSource>();
        this._boxCollider = this.GetComponent<BoxCollider>();
    }
    public void ToggleDoor()
    {
        // Toggle the door's state (open or closed)
        if (CheckDoorLocked())
        {
            isOpen = !isOpen;
            if (isOpen == true)
            {
                this.doorAudioSouce.clip = doorAudio[0];
                _boxCollider.isTrigger = true;
            }
            else
            {
                this.doorAudioSouce.clip = doorAudio[1];
                _boxCollider.isTrigger = false;
            };
            this.doorAudioSouce.Play();
            doorAnimator.SetBool("IsDoorActive", isOpen);
        }
    }
    public bool CheckDoorLocked()
    {
        switch (_currentDoor)
        {
            case Doors.Other:
                    return true;
        }
        return false;
    }

}
