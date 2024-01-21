using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingIntro : MonoBehaviour
{
    [SerializeField] private GameObject startingPanel;
    [SerializeField] private Button closeBTN;
    private void Start()
    {
        OnIntrOpened(true);
        OpenAndClose(true);
        closeBTN.onClick.AddListener(Close);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }

    private void Close()
    {
        OpenAndClose(false);
        OnIntrOpened(false);
    }
    

    private void OpenAndClose(bool isOpen)
    {
        if (isOpen)
        {
            startingPanel.SetActive(true);
        }
        else
        {
            startingPanel.SetActive(false);
        }
        
    }

    private void OnIntrOpened(bool isOpened)
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

}
