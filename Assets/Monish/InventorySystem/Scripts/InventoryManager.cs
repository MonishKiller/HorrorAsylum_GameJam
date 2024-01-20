using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<SO_Item> items = new List<SO_Item>();

    public Transform itemCrafting_Pos;
    public GameObject crafting_inventoryItem;

    public Transform itemConsumable_Pos;
    public GameObject consumable_inventoryItem;

    [SerializeField] private List<SO_Item> consumable_Items = new List<SO_Item>();

    //Todo Move this to UI_Manager

    [SerializeField] private Inventory_Panel inventory_Panel;


    public void EnableInventory()
    {
        inventory_Panel.OnEnable_Inventory();
        Initialize_CraftingItem_UI();
    }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
      // Initialize_ConsumableItem_UI();

    }
    /// <summary>
    /// Updated The UI of collected Item in the Game
    /// </summary>
    public void Initialize_CraftingItem_UI()
    {
        //To Destroy the Previous List
        foreach (Transform item in itemCrafting_Pos)
        {
            Destroy(item.gameObject);
        }

        foreach (var currentItem in items)
        {
            GameObject obj = Instantiate(crafting_inventoryItem, itemCrafting_Pos);
            //Make Sure to set the Enum None if Its not Crafting Item
            obj.GetComponent<Item_Inventory_UI>().Initialize(currentItem.ItemIcon, currentItem.ItemName,
                currentItem.ItemValue,currentItem.ItemType,currentItem);

        }
    }

    public void ShowCurrent_Item(GameObject currentItem)
    {
        inventory_Panel.Instantiate_Item(currentItem);
        
    }


    public void AddItem(SO_Item item_data)
    {
        items.Add(item_data);
    }

    public void RemoveItem(SO_Item item_data)
    {
        items.Remove(item_data);
    }
/*
    public void CraftItem(ConsumableItem consumableItem)
    {
        switch (consumableItem)
        {
            case ConsumableItem.TakeDown:
                if (MergeItem(CraftingItem.Chloroform, CraftingItem.Tissue))
                {
                    UpdateConsumable_Item_SOData(ConsumableItem.TakeDown);
                    Initialize_ConsumableItem_UI();

                }
                break;
            case ConsumableItem.SleepingDart:
                break;
            case ConsumableItem.SmokeBomb:
                break;
            case ConsumableItem.HealthPortion:
                break;
            default:
                Debug.Log($"Inventory Manager : <color=Red>Error</color> Cant Craft ITem");
                break;


        }


    }
    private bool MergeItem(CraftingItem craftingItem1, CraftingItem craftingItem2, CraftingItem craftingItem3 = CraftingItem.None)
    {
        if (CheckItem_Inventory(craftingItem1) && CheckItem_Inventory(craftingItem2))
        {
            Debug.Log($"Inventory Mananger<color=lime> Required Item is in Inventory</color>");
            RemoveItem_Inventory(craftingItem1);
            RemoveItem_Inventory(craftingItem2);
            Initialize_CraftingItem_UI();

            return true;
        }
        else
        {
            Debug.Log($"Inventory Mananger<color=Red> Required Item is Not in Inventory</color>");
            return false;

        }


    }
    private bool CheckItem_Inventory(CraftingItem craftingItem)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (craftingItem == items[i].CraftingItem)
            {
                return true;
            }
        }
        return false;

    }
    private void RemoveItem_Inventory(CraftingItem craftingItem)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (craftingItem == items[i].CraftingItem)
            {
                RemoveItem(items[i]);
                break;
            }
        }

    }

    private void UpdateConsumable_Item_SOData(ConsumableItem consumableItem)
    {
        for (int i = 0; i < consumable_Items.Count; i++)
        {
            if (consumableItem == consumable_Items[i].ConsumableItem)
            {
                //Can Change Later According to the Requirements
                int value = 1;
                consumable_Items[i].UpdateValue(value);
            }
        }


    }

    /// <summary>
    /// Shows the Item Which Can be Crafted in the UI
    /// </summary>
    public void Initialize_ConsumableItem_UI()
    {
        //To Destroy the Previous List
        foreach (Transform item in itemConsumable_Pos)
        {
            Destroy(item.gameObject);
        }

        foreach (var currentItem in consumable_Items)
        {
            GameObject obj = Instantiate(consumable_inventoryItem, itemConsumable_Pos);
            //Make Sure to set the Enum None if Its not Crafting Item
            obj.GetComponent<Item_Inventory_UI>().Initialize(currentItem.ItemIcon, currentItem.ItemName, currentItem.ItemValue,
            currentItem.ConsumableItem, currentItem.CraftingItem);

        }
    }
    */
    




}
