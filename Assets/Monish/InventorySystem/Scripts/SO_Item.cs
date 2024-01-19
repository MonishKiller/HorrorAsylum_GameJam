using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create new Item")]
public class SO_Item : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _itemName;
    [SerializeField] private int _itemValue;
    [SerializeField] private Sprite _itemIcon;

    //[SerializeField] private ItemType _itemType;
    //[SerializeField] private CraftingItem _craftinItem;
    //[SerializeField] private ConsumableItem _consumableITem;

    public int ID { get { return _id; } }
    public string ItemName { get { return _itemName; } }
    public int ItemValue { get { return _itemValue; } }
    public Sprite ItemIcon { get { return _itemIcon; } }

    //  public ConsumableItem ConsumableItem => this._consumableITem;
    // public CraftingItem CraftingItem => this._craftinItem;
  //  public ItemType ItemType => this._itemType;


    public void UpdateValue(int value)
    {
        this._itemValue += value;
    }





}
