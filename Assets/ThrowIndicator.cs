using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowIndicator : MonoBehaviour
{
    private ThrowObjects[] _allthrowobjects;
    private Transform player; // Assign the player's transform in the Unity Editor
    public float detectionRadius = 5f;
    private bool playerInsideSphere = false;

    private void Start()
    {
        player = FindObjectOfType<Player_Actions>().transform;
        _allthrowobjects = FindObjectsOfType<ThrowObjects>();
    }

    private void InvokeThrow()
    {
        for(int i=0;i<_allthrowobjects.Length;i++)
        {
            _allthrowobjects[i].ThrowRandom();
        }
    }

    private void Update()
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
               Invoke("InvokeThrow",2f); 
                
            }
        }
        else
        {
            // Player exited the sphere
            if (playerInsideSphere)
            {
                playerInsideSphere = false;
                Debug.Log("Player exited the custom sphere.");
            
            }
        }
        
    }
}
