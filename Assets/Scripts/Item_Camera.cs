using System.Collections;
using System.Collections.Generic;
using GameEnum.Templates;
using UnityEngine;

public class Item_Camera : MonoBehaviour,IInteractable
{
    [SerializeField] private GameObject EndScreen;
    private void OnEndScreen()
    {
        EndScreen.SetActive(true);
    }


    public void Interact()
    {
        this.OnEndScreen();
    }
}
