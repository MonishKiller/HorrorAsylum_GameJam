using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Camera : MonoBehaviour
{
    [SerializeField] private GameObject EndScreen;
    public void OnEndScreen()
    {
        EndScreen.SetActive(true);
        
    }
   
}
