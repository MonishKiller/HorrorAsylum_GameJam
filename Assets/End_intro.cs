using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_intro : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0.1f;
        OnPuzzleOpened(true);
        
    }
    private void OnPuzzleOpened(bool isOpened)
    {
        if (isOpened)
        {
            Time.timeScale = 0.1f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            
        }
        
    }

    public void End_Clicked()
    {
        Application.Quit();
    }
   
}
