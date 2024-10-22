using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Data", menuName ="Inventory Package/Create new Item", order = 1)]
public class InventoryItemData : ScriptableObject
{
   [Tooltip("Unique Item ID.")]
   public string itemId;

   [Tooltip("Item name, to be appear in Inventory.")]
   public string itemName;

   [Tooltip("Item 2D Sprite, to show in Inventory.")]
   public Sprite itemIcon;

   [Tooltip("Item GameObject.")]
   public GameObject itemPrefab;

   [TextArea(17,1000)]
   public string comment =" type comments here";

}
