using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [Header("SO Item Data ")]
    [SerializeField] private SO_Item item_Data;

    //Todo Add partical and Dotween Effects For Item in Here

    private void Awake()
    {
        if (item_Data == null) Debug.Log($"<color=lime> Items Prefabs</color> : The So Item Data is not Set");

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("There is Activity");
            AddItem_Inventory();
        }

    }


    private void AddItem_Inventory()
    {
        InventoryManager.Instance.AddItem(item_Data);
        Destroy(gameObject);
    }

}
