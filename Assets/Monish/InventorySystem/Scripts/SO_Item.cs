using UnityEngine;
using GameEnum;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create new Item")]
public class SO_Item : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _itemName;
    [SerializeField] private int _itemValue;
    [SerializeField] private Sprite _itemIcon;
    [SerializeField] private ItemType _itemType;
    [SerializeField] private GameObject _itemObj;
    [SerializeField] private string _itemDescription;
    
    public int ID { get { return _id; } }
    public string ItemName { get { return _itemName; } }
    public int ItemValue { get { return _itemValue; } }
    public Sprite ItemIcon { get { return _itemIcon; } }

 
    public ItemType ItemType => this._itemType;
    public GameObject ItemObj => this._itemObj;

    public string ItemDescription => this._itemDescription;


    public void UpdateValue(int value)
    {
        this._itemValue += value;
    }





}
