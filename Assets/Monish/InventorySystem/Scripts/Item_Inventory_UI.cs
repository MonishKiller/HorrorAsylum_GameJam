using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item_Inventory_UI : MonoBehaviour
{
 //   [SerializeField] private ItemType _itemType;
   // [SerializeField] private ConsumableItem _consumableItem;
    //[SerializeField] private CraftingItem _craftingItem;

    #region References_UI
    [SerializeField] private Image _item_Image;
    [SerializeField] private TextMeshProUGUI _item_Name;
    [SerializeField] private TextMeshProUGUI _item_Count;
    [SerializeField] private Toggle _item_Toggle;
    #endregion References_UI

    #region  Unity_Methods
    private void Start()
    {
        _item_Toggle.group = this.gameObject.GetComponentInParent<ToggleGroup>();
        _item_Toggle.onValueChanged.AddListener(OnClick_Item_Selected);
    }
    #endregion Unity_Methods

    public void Initialize(Sprite item_Sprite, string item_Name, int item_Count)
    {
        this._item_Image.sprite = item_Sprite;
        this._item_Name.text = item_Name;
        this._item_Count.text = item_Count.ToString();

    }
    private void OnClick_Item_Selected(bool isActive)
    {
        if (isActive)
        {
            Debug.Log($"The {(this._item_Name.text)} is Selected");
         //  if (_itemType == ItemType.Consumable)
           // {
             //   RequestToAdd_ConsumableItem();
           // }

        }

    }
    private void RequestToAdd_ConsumableItem()
    {
        Debug.Log($"The RequestTo Add Called ");
   //     InventoryManager.Instance.CraftItem(this._consumableItem);


    }
    private void RequestToDrop_CraftingItem()
    {

    }




}
