using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Inventory_Panel : MonoBehaviour
{
    [SerializeField] private Button inventory_Close_BTN;
    [SerializeField] private TextMeshProUGUI TMP_ItemDescription;
    [SerializeField] private TextMeshProUGUI TMP_ItemTitle;

    private void Awake()
    {
        // Enable the cursor at the start
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        if (this.inventory_Close_BTN != null) this.inventory_Close_BTN.onClick.AddListener(OnClicked_Inventory_Close_BTN);
        else Debug.Log($"Inventory Panel  : The Close button is not set ");
    }
    #region Events

    private void OnInventoryOpened(bool isOpened)
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
    private void OnClicked_Inventory_Close_BTN()
    {
        OnInventoryOpened(false);
        this.gameObject.SetActive(false);
    }
    public void OnEnable_Inventory()
    {
        OnInventoryOpened(true);
        this.gameObject.SetActive(true);
    }
    public Camera rotationCamera;
    private bool isDragging = false;
    private Vector3 initialMousePos;
    public float rotationSpeed = 5f;
    
    public GameObject targetobj;
    public Transform InitialTransform;

   private bool isCurrentItemShowing;

   public void Instantiate_Item(GameObject go,SO_Item soItem )
   {
       if (targetobj == null)
       {
          targetobj= Instantiate(go, InitialTransform.position, Quaternion.identity);
         
       }
       else
       {
           if (targetobj != go)
           {
               Destroy(targetobj);
               targetobj = null;
               targetobj=Instantiate(go, InitialTransform.position, Quaternion.identity);
           }
       }

       TMP_ItemDescription.text = soItem.ItemDescription;
       TMP_ItemTitle.text = soItem.ItemName;
       isCurrentItemShowing = true;

   }
    void Update()
    {
        if (isCurrentItemShowing)
        {
            // Check for mouse button down to start dragging
            if (Input.GetMouseButtonDown(0))
            {
                // Raycast from the specified camera
                Ray ray = rotationCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the hit object is the object this script is attached to
                    if (hit.collider.gameObject)
                    {
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
                targetobj.transform.Rotate(Vector3.right, rotationX, Space.Self);
                targetobj.transform.Rotate(Vector3.up, rotationY, Space.World);

                // Update initial mouse position for the next frame
                initialMousePos = Input.mousePosition;
            }
        }
    }
    #endregion Events
}
