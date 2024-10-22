[System.Serializable]
public class InventoryItem
{
    public InventoryItemData data;
    public int stackQty;

    public InventoryItem(InventoryItemData itemData)
    {
        data = itemData;

        AddStack();
    }

    public void AddStack()
    { 
        stackQty++;
    }
    public void RemoveStack()
    { 
        stackQty--;
    }

    


}
