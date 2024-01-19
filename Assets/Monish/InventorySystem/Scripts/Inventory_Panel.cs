using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Panel : MonoBehaviour
{
    //Todo Change Panel Archietecture similar to DA 

    [SerializeField] private Button inventory_Close_BTN;

    private void Awake()
    {
        if (this.inventory_Close_BTN != null) this.inventory_Close_BTN.onClick.AddListener(OnClicked_Inventory_Close_BTN);
        else Debug.Log($"Inventory Panel  : The Close button is not set ");
    }
    #region Events
    private void OnClicked_Inventory_Close_BTN()
    {
        this.gameObject.SetActive(false);
    }
    public void OnEnable_Inventory()
    {
        this.gameObject.SetActive(true);
    }
    #endregion Events
}
