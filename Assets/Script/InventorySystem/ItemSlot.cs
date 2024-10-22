using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI _itemName;
   
   [SerializeField] private Image _itemIcon;
   [SerializeField] private GameObject _stackQtyBgn;

   [SerializeField] private TextMeshProUGUI _stackQty;


   public void Set(InventoryItem item)
   {
        _itemName.text = item.data.itemName;
        _itemIcon.sprite = item.data.itemIcon;
        
        if(item.stackQty > 1)
        {
            _stackQtyBgn.SetActive(true);
            _stackQty.enabled = true;
            _stackQty.text = item.stackQty.ToString();
        }
        else
        {
             _stackQtyBgn.SetActive(false);
             _stackQty.enabled = false;
        }


   }
}
