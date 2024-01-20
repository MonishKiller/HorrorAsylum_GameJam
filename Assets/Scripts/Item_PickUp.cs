using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_PickUp : MonoBehaviour
{
    [SerializeField] private SO_Item itemSO;

    public void ItemPicked()
    {
        InventoryManager.Instance.AddItem(itemSO);
        Destroy(this.gameObject);
        
    }
}
