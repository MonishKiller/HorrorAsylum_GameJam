using System;
using System.Collections;
using System.Collections.Generic;
using GameEnum;
using UnityEngine;

public class Item_PickUp : MonoBehaviour
{
    [SerializeField] private SO_Item itemSO;

    public void ItemPicked()
    {
        InventoryManager.Instance.AddItem(itemSO);
        if(itemSO.ItemType==ItemType.Key)
           InventoryManager.Instance.EnableInventory();
        Destroy(this.gameObject);
        
    }
    
}
