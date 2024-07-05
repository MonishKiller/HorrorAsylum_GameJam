using System;
using System.Collections;
using System.Collections.Generic;
using GameEnum;
using GameEnum.Templates;
using UnityEngine;

public class Item_PickUp : MonoBehaviour,IInteractable
{
    [SerializeField] private SO_Item itemSO;

    private void ItemPicked()
    {
        InventoryManager.Instance.AddItem(itemSO);
        if (itemSO.ItemType == ItemType.Key)
        {
            InventoryManager.Instance.EnableInventory();
        }

        Destroy(this.gameObject);
        
    }

    public void Interact()
    {
        this.ItemPicked();
    }
}
