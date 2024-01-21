using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropIndicator : MonoBehaviour
{
    private FallObjects[] _allfallobjects;
    private Transform player; // Assign the player's transform in the Unity Editor
    public float detectionRadius = 5f;
    private bool playerInsideSphere = false;
    private bool auidoPlayed = false;

    private void Start()
    {
        player = FindObjectOfType<Player_Actions>().transform;
        _allfallobjects = FindObjectsOfType<FallObjects>();
    }

    private void InvokeThrow()
    {
        for(int i=0;i<_allfallobjects.Length;i++)
        {
            _allfallobjects[i].DropRandom();
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
                if (!auidoPlayed)
                {
                    Invoke("InvokeThrow", 1f);
                    auidoPlayed = true;
                }

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
