using System.Collections;
using System.Collections.Generic;
using GameEnum;
using GameEnum.Templates;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
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

    public void Interact()
    {
        CheckDoorAndInteract();
    }
    
    void CheckDoorAndInteract()
    {
        if (this.isUnlocked)
        {
            this.ToggleDoor();
        }
        else
        {
            if (this._doorType == keyType.None)
            {
                this.UnlockDoor();
                this.ToggleDoor();
            }
            if (InventoryManager.Instance.CheckKeyAvailable(this._doorType))
            {
                this.UnlockDoor();
                this.ToggleDoor();
            }
            else
            {
                MainCanvas_UI.Instance.Show_Message("LOCKED");
            }
            
        }
    }
}
