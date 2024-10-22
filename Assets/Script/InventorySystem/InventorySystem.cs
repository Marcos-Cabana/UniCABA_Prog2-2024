using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;
    public delegate void OnInventoryChangeEvent();

    public event OnInventoryChangeEvent OnInventoryChangeEventCallback;

    private Dictionary<InventoryItemData, InventoryItem> _inventoryDictionary;
    public List<InventoryItem> inventory;

    private void Awake() 
    {
        inventory = new List<InventoryItem>();
        _inventoryDictionary = new Dictionary<InventoryItemData, InventoryItem>();

        Instance = this;
    }

    public void Add(InventoryItemData itemData)
    {
        if(_inventoryDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            //item exist add one to stack
            item.AddStack();
        }
        else
        {
            //item dont exist add it to Dictionary
            InventoryItem newItem = new InventoryItem(itemData); 
            inventory.Add(newItem);

            _inventoryDictionary.Add(itemData, newItem);

        }

        OnInventoryChangeEventCallback.Invoke();
    }

    public void Remove(InventoryItemData itemData)
    {
        if(_inventoryDictionary.TryGetValue(itemData, out InventoryItem item))
        {
            //item exist remove one from stack
            item.RemoveStack();
        }
        
        if(item.stackQty == 0)
        {
            //if item quantity is equal to zero, remove item from Dictionary
            inventory.Remove(item);

            _inventoryDictionary.Remove(itemData);
        }

        OnInventoryChangeEventCallback.Invoke();
    }
}
