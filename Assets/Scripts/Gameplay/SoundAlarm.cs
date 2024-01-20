using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SoundAlarm : MonoBehaviour
{
    public enum ObjectsSounds
    {
        WheelChair=0,
        Bathroom=1,
        Kitchen=2,
        Dining=3,
        VC=4
    }
    
    private Transform player; // Assign the player's transform in the Unity Editor
    public float detectionRadius = 5f;
    public ObjectsSounds _currentObjects;
    private bool playerInsideSphere = false;
    private AudioSource _audioSource;
    private bool audioPlayed;
    
   
    private void Start()
    {
        player = FindObjectOfType<Player_Movement>().transform;
        _audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check the distance between the player and the center of the sphere
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is inside the custom sphere
        if (distanceToPlayer <= detectionRadius)
        {
            // Player entered the sphere
            if (!playerInsideSphere)
            {
                playerInsideSphere = true;
                CheckOnobject_Response();
            }
        }
        else
        {
            // Player exited the sphere
            if (playerInsideSphere)
            {
                playerInsideSphere = false;
                CheckOnobject_Response();
                Debug.Log("Player exited the custom sphere.");
            
            }
        }
    }

    private void Sound_wheelChair()
    {
        if (!playerInsideSphere && !audioPlayed)
        {
            _audioSource.Play();
            audioPlayed = true;

        }
        
    }
    private void Sound_Bathroom()
    {
        if (playerInsideSphere && !audioPlayed)
        {
            _audioSource.Play();
            audioPlayed = true;
        }
        
    }
    private void Sound_Kitchen()
    {
        if (playerInsideSphere && !audioPlayed)
        {
            _audioSource.Play();
            audioPlayed = true;
        }
        
    }
    private void CheckOnobject_Response()
    {
        switch (this._currentObjects)
        {
            case ObjectsSounds.WheelChair:
                Sound_wheelChair();
                break;
            case ObjectsSounds.Bathroom:
                Sound_Bathroom();
                break;
            case ObjectsSounds.Kitchen:
                Sound_Kitchen();
                break;
            case ObjectsSounds.Dining:
                Sound_Kitchen();
                break;
            case ObjectsSounds.VC:
                Sound_Kitchen();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    void OnDrawGizmos()
    {
        // Draw the detection radius using Gizmos
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
    
}
