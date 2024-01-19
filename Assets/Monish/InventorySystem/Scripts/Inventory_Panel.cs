using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Panel : MonoBehaviour
{
    //Todo Change Panel Archietecture similar to DA 

    [SerializeField] private Button inventory_Close_BTN;

    private void Awake()
    {
        
        // Enable the cursor at the start
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        if (this.inventory_Close_BTN != null) this.inventory_Close_BTN.onClick.AddListener(OnClicked_Inventory_Close_BTN);
        else Debug.Log($"Inventory Panel  : The Close button is not set ");
    }
    #region Events
    private void OnClicked_Inventory_Close_BTN()
    {
        this.gameObject.SetActive(false);
    }
    public void OnEnable_Inventory()
    {
        this.gameObject.SetActive(true);
    }
    public Camera rotationCamera;
    private bool isDragging = false;
    private Vector3 initialMousePos;
    public float rotationSpeed = 5f;
    public GameObject prefab;
    void Update()
    {
        // Check for mouse button down to start dragging
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from the specified camera
            Ray ray = rotationCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.LogError("HIT");
                // Check if the hit object is the object this script is attached to
                if (hit.collider.gameObject)
                {
                    Debug.LogError("HIT GO");
                    isDragging = true;
                    initialMousePos = Input.mousePosition;
                }
            }
        }

        // Check for mouse button release to stop dragging
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Rotate the object while dragging
        if (isDragging)
        {
            // Calculate the rotation amounts based on the mouse movement
            float rotationX = (Input.mousePosition.y - initialMousePos.y) * rotationSpeed * Time.deltaTime;
            float rotationY = (Input.mousePosition.x - initialMousePos.x) * rotationSpeed * Time.deltaTime;

            // Apply rotation to the object around its local axes
            prefab.transform.Rotate(Vector3.right, rotationX, Space.Self);
            prefab.transform.Rotate(Vector3.up, rotationY, Space.World);

            // Update initial mouse position for the next frame
            initialMousePos = Input.mousePosition;
        }
    }
    #endregion Events
}
