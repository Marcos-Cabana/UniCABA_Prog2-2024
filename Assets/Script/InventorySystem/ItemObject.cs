using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
   [SerializeField]private bool _isInteractuable;
   [SerializeField]private bool _isCollectable;

    public bool IsCollectable{get{return _isCollectable;} set{_isCollectable = value;}}
    public bool IsInteractuable{get; set;}
   
    public InventoryItemData itemData;
   
    public void OnPickUp()
    {
        InventorySystem.Instance.Add(itemData);
        Destroy(gameObject);
    }
}
