using System.Collections;
using System.Collections.Generic;
using GameEnum;
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
    [SerializeField] private GameObject[] puzzelType;
    public void EnableDisablePuzzle(int puzzleNo,bool enable)
    {
        if (!enable)
        {
            puzzelType[puzzleNo].GetComponent<Item_Puzzle>().HideandUnHide(true);
        }
        else
        {
            puzzelType[puzzleNo].GetComponent<Item_Puzzle>().HideandUnHide(false);
        }
        
    }

    public void PuzzleSolved(int puzzleNo)
    { 
        puzzelType[puzzleNo].GetComponent<Item_Puzzle>().PuzzleSolved();
        
    }

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

    public void ShowCurrent_Item(GameObject currentItem,SO_Item soItem)
    {
        inventory_Panel.Instantiate_Item(currentItem,soItem);
        
    }
    
    public void AddItem(SO_Item item_data)
    {
        items.Add(item_data);
    }

    public void RemoveItem(SO_Item item_data)
    {
        items.Remove(item_data);
    }

    public bool CheckKeyAvailable(keyType currentKey)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ItemType == ItemType.Key)
            {
                if (items[i].KeyType == currentKey)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
