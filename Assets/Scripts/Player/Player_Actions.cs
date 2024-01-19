using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_Actions : MonoBehaviour
{
    [Header("Variables")]

    Camera _mainCamera;
    Ray _ray = new Ray();
    Ray _ray2 = new Ray();
    RaycastHit _hit;
    private Door door = new Door();
    private Lights_Environment lights = new Lights_Environment();
    private Player_Audio _player_Audio;
    private GameObject _candle;
    private void Start()
    {
        _mainCamera = Camera.main;
        _player_Audio = this.GetComponent<Player_Audio>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckForInteractables();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            CheckForJournal();
        }

    }
    private void FixedUpdate()
    {
        Check_UI();
    }
    private void Check_UI()
    {
        _ray2 = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray2, out _hit, 2f))
        {
           /* if (_hit.collider.gameObject.CompareTag("Door") || _hit.collider.gameObject.CompareTag("Lights")
            || _hit.collider.gameObject.CompareTag("Letter") || _hit.collider.gameObject.CompareTag("Candle"))
            {
               // MainCanvas_UI.Instance.Show_Helper();
            }
            else
            {
              //  MainCanvas_UI.Instance.Hide_Helper();
            }
            */
           if (_hit.collider.gameObject.CompareTag("Door"))
           {
                MainCanvas_UI.Instance.Show_Helper();
           }
           else
           {
                 MainCanvas_UI.Instance.Hide_Helper();
           }
        }
        
    }

    private void CheckForJournal()
    {
        //MainCanvas_UI.Instance.Show_LetterPanel();
    }

    private void CheckForInteractables()
    {
        _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        // Define the maximum raycast distance.
        float maxRaycastDistance = 5f;
        // Perform the raycast.
        Debug.LogError("firing");
        if (Physics.Raycast(_ray, out _hit, maxRaycastDistance))
        {
            if (_hit.collider.gameObject.CompareTag("Door"))
            {
                Debug.LogError("firing2");
                ToggleDoor(_hit.collider.gameObject);
            }
         
        }
        /*
        if (_hit.collider.gameObject.CompareTag("Lights"))
        {
            ToggleLights(_hit.collider.gameObject);
        }
        if (_hit.collider.gameObject.CompareTag("Letter"))
        {
            PickLetter(_hit.collider.gameObject);
        }
        if (_hit.collider.gameObject.CompareTag("Candle"))
        {
            PickLetter(_hit.collider.gameObject);
        }
        */
    }
    private void PickCandle()
    {
        _candle.SetActive(true);
    }
    private void PickLetter(GameObject go)
    {
        _player_Audio.Player_Audio_PickUp_Letter();
        //go.GetComponent<Letter>().SelectedTheLetter();
    }
    private void ToggleDoor(GameObject go)
    {
        door = go.GetComponent<Door>();
        door.ToggleDoor();
    }
    private void ToggleLights(GameObject go)
    {
        _player_Audio.Player_Audio_PicKUp_Object();

        lights = go.GetComponent<Lights_Environment>();
        if (lights.LightActive) { lights.SetLightActive(false); }
        else { lights.SetLightActive(true); }
    }

}
